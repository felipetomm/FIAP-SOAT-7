using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Infrastructure.IoC.Modules.System;

public static partial class InjectSystem
{
    public static void Register(IServiceCollection services)
    {
        RegisterApplication(services);
        RegisterDomain(services);
        RegisterExternalService(services);
        RegisterRepository(services);
    }
}