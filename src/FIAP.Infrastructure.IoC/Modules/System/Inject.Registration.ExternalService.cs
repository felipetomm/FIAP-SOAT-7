using FIAP.Domain.Interfaces.ExternalServices;
using FIAP.ExternalService.WebAPI.Payments.FakePaymentGateway;

using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Infrastructure.IoC.Modules.System;

public static partial class InjectSystem
{
    public static void RegisterExternalService(IServiceCollection services)
    {
        services.AddScoped<IFakePaymentGatewayService, FakePaymentGatewayService>();
    }
}