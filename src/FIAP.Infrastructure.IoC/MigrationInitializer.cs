using FIAP.Domain.Entities.Infra;
using FIAP.Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Data.Common;
using System.Text.RegularExpressions;

namespace FIAP.Infrastructure.IoC;
public static class MigrationInitializer
{
    public static IServiceProvider ApplyMigrationsSystemContext(this IServiceProvider provider, IServiceScope scope)
    {
        var context = scope.ServiceProvider.GetService<BaseDbContext>();
        var env = provider.GetService<IHostEnvironment>();

        var finalPath = env.IsDevelopment() ? "../../sql" : "/app/sql";

        // Por enquanto só executa em prod
        if (env.IsProduction())
            Seed(context, finalPath);

        return provider;
    }

    private static void Seed(BaseDbContext dbContext, string sqlPath)
    {
        var builder = new DbConnectionStringBuilder();
        builder.ConnectionString = dbContext.Database.GetConnectionString();

        PrintConsole([
            $"{DateTime.Now} DbInitializer -> Database is {builder["Database"]} at {builder["Server"]}",
            $"{DateTime.Now} DbInitializer -> Updating database..."
        ]);

        using (var trans = dbContext.Database.BeginTransaction())
        {
            // Garante que irá existir o banco
            var initialSqlCommand = LoadInitialSqlFile(sqlPath);

            dbContext.Database.ExecuteSqlRaw(initialSqlCommand);

            dbContext.SaveChanges();

            // Depois, pega todos os arquivos sql que estão versionados (iniciam pela letra "V")
            var migrationFiles = LoadMigrationsFile(sqlPath);

            if (migrationFiles.Any())
            {
                foreach (var migrationFile in migrationFiles)
                {
                    if (dbContext.DatabaseUpdates.Any(x => x.FileName == migrationFile.FileName))
                        continue;

                    PrintConsole([$"{DateTime.Now} DbInitializer -> Applying update {migrationFile.FileName}"]);

                    try
                    {
                        dbContext.Database.ExecuteSqlRaw(migrationFile.Content, 1800);
                        PrintConsole([$"{DateTime.Now} DbInitializer -> - OK"]);
                    }
                    catch (Exception ex)
                    {
                        PrintConsole([$"{DateTime.Now} DbInitializer -> - ERROR: {ex.Message} / InnerException: {ex.InnerException?.Message ?? "empty inner exception"}"], ConsoleColor.Red);
                        throw;
                    }

                    var updateDatabase = new DatabaseUpdates
                    {
                        FileName = migrationFile.FileName,
                        Content = migrationFile.Content,
                        Created = DateTime.Now,
                    };

                    dbContext.DatabaseUpdates.Add(updateDatabase);
                }
            }

            dbContext.SaveChanges();

            trans.Commit();

            PrintConsole([$"{DateTime.Now} DbInitializer -> Done."]);
        }
    }

    private static void PrintConsole(string[] args, ConsoleColor color = ConsoleColor.Green)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }
        Console.WriteLine();
        Console.ForegroundColor = originalColor;
    }

    private static string LoadInitialSqlFile(string path)
    {
        var filePath = Directory.GetFiles(path, "sql-initial.sql").FirstOrDefault();
        ArgumentException.ThrowIfNullOrEmpty(filePath);

        var fileInfo = new FileInfo(filePath);
        ArgumentNullException.ThrowIfNull(fileInfo);

        return File.ReadAllText(fileInfo.FullName);
    }

    private static List<DataImportSql> LoadMigrationsFile(string path)
    {
        var result = new List<DataImportSql>();

        foreach (var file in Directory.GetFiles(path, "V*.sql"))
        {
            var fileInfo = new FileInfo(file);

            var data = new DataImportSql
            {
                FileName = fileInfo.Name,
                Content = File.ReadAllText(fileInfo.FullName)
            };

            result.Add(data);
        }

        // Ordena os arquivos de acordo com a sua versão
        return result
            .OrderBy(x => int.Parse(Regex.Match(x.FileName, @"\d+").Value))
            .ToList();
    }

    private sealed class DataImportSql
    {
        public string FileName { get; set; }
        public string Content { get; set; }
    }
}