using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FIAP.Infrastructure.Data.Context;
public partial class BaseDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public BaseDbContext(DbContextOptions<BaseDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // First run System models
        CreatingSystem(modelBuilder);

        // Others
        CreatingStore(modelBuilder);

        // Then, Call the base method
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public void SetDetached<TEntity>(TEntity entity) where TEntity : class
    {
        Entry(entity).State = EntityState.Unchanged;
    }

    /// <summary>
    /// Desatacha todas as entidades do contexto
    /// </summary>
    public void DetachAll()
    {
        foreach (var entityEntry in ChangeTracker.Entries().ToArray())
        {
            if (entityEntry.Entity != null)
            {
                entityEntry.State = EntityState.Detached;
            }
        }
    }
}