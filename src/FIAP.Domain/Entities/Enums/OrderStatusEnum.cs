using System.ComponentModel;

using FIAP.Infrastructure.CrossCutting.Attributes;

namespace FIAP.Domain.Entities.Enums;

public enum OrderStatus
{
    [Description("Recebido")]
    [AlternateValue("RECEIVED")]
    RECEIVED = 1,

    [Description("Enviado para a cozinha")]
    [AlternateValue("SENT_TO_KITCHEN")]
    SENT_TO_KITCHEN = 2,

    [Description("Em preparação")]
    [AlternateValue("IN_PREPARATION")]
    IN_PREPARATION = 3,

    [Description("Rejeitado")]
    [AlternateValue("REJECTED")]
    REJECTED = 4,

    [Description("Pronto")]
    [AlternateValue("READY")]
    READY = 5,

    [Description("Finalizado")]
    [AlternateValue("FINISHED")]
    FINISHED = 6,
}