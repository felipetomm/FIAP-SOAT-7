using FIAP.Infrastructure.Data.Context;
using FIAP.Infrastructure.IoC.Modules.System;

using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Infrastructure.IoC;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        // Register all ioc
        InjectSystem.Register(services);

        // Add database context
        services.AddDbContext<BaseDbContext>(ServiceLifetime.Scoped);
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}