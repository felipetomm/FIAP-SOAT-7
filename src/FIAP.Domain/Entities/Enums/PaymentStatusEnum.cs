using System.ComponentModel;

using FIAP.Infrastructure.CrossCutting.Attributes;

namespace FIAP.Domain.Entities.Enums;

public enum PaymentStatus
{
    [Description("Pendente")]
    [AlternateValue("PENDING")]
    PENDING = 1,

    [Description("Aprovado")]
    [AlternateValue("APPROVED")]
    APPROVED = 2,

    [Description("Rejeitado")]
    [AlternateValue("REJECTED")]
    REJECTED = 3,

    [Description("Erro")]
    [AlternateValue("ERROR")]
    ERROR = 4,

    [Description("Cancelado")]
    [AlternateValue("CANCELED")]
    CANCELED = 5,
}