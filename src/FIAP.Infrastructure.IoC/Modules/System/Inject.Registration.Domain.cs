using FIAP.Infrastructure.CrossCutting.Interfaces;
using FIAP.Infrastructure.Data.Context;

using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Infrastructure.IoC.Modules.System;

public static partial class InjectSystem
{
    public static void RegisterDomain(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}