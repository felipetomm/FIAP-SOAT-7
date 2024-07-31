using System.ComponentModel;

using FIAP.Infrastructure.CrossCutting.Attributes;

namespace FIAP.Domain.Entities.Enums;

public enum PaymentGateway
{
    [Description("Fake Gateway")]
    [AlternateValue("FAKE_GATEWAY")]
    FAKE_GATEWAY = 1,

    [Description("Mercado Livre")]
    [AlternateValue("MERCADO_LIVRE")]
    MERCADO_LIVRE = 2,

    [Description("Bradesco")]
    [AlternateValue("BRADESCO")]
    BRADESCO = 3,

    [Description("Itaú")]
    [AlternateValue("ITAU")]
    ITAU = 4,

    [Description("Santander")]
    [AlternateValue("SANTANDER")]
    SANTANDER = 5,

    [Description("Nu Bank")]
    [AlternateValue("NUBANK")]
    NUBANK = 6,

    [Description("Stone")]
    [AlternateValue("STONE")]
    STONE = 7,
}