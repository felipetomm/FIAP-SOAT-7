using FIAP.Domain.Entities.Enums;
using FIAP.Infrastructure.CrossCutting.Extensions;

namespace FIAP.Application.OutputModels;

public class CheckPaymentOutputModel
{
    public decimal Amount { get; set; }
    public GatewayModel Gateway { get; set; }
    public StatusModel Status { get; set; }

    public class GatewayModel
    {
        public string Label { get; private set; }
        public PaymentGateway Value { get; private set; }

        public GatewayModel(PaymentGateway gateway)
        {
            Label = gateway.ToDescription();
            Value = gateway;
        }
    }

    public class StatusModel
    {
        public string Label { get; private set; }
        public PaymentStatus Value { get; private set; }

        public StatusModel(PaymentStatus status)
        {
            Label = status.ToDescription();
            Value = status;
        }
    }
}