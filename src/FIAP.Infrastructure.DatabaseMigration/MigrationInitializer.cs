public static class MigrationInitializer
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            var context = serviceScope
                .ServiceProvider
                .GetService<Context>();

            context!.Database.Migrate();
        }
    }
}