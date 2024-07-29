using System.ComponentModel;

namespace FIAP.Domain.Entities.Enums;

public enum OrderStatus
{
    [Description("Recebido")]
    RECEIVED = 1,

    [Description("Enviado para a cozinha")]
    SENT_TO_KITCHEN = 2,

    [Description("Em preparação")]
    IN_PREPARATION = 3,

    [Description("Rejeitado")]
    REJECTED = 4,

    [Description("Pronto")]
    READY = 5,

    [Description("Finalizado")]
    FINISHED = 6,
}