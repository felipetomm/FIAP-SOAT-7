using FIAP.Application.Interfaces;
using FIAP.Application.Services;

using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Infrastructure.IoC.Modules.System;

public static partial class InjectSystem
{
    public static void RegisterApplication(IServiceCollection services)
    {
        services.AddScoped<ICustomerUseCases, CustomerUseCases>();
        services.AddScoped<IOrderUseCases, OrderUseCases>();
        services.AddScoped<IProductUseCases, ProductUseCases>();
    }
}