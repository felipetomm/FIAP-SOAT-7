using FIAP.Domain.Interfaces.Repositories;
using FIAP.Infrastructure.Data.Context.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Infrastructure.IoC.Modules.System;

public static partial class InjectSystem
{
    public static void RegisterRepository(IServiceCollection services)
    {
        services.AddScoped<ICustomersRepository, CustomersRepository>();
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();
    }
}