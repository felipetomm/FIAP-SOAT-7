using System.ComponentModel;

namespace FIAP.Domain.Entities.Enums;

public enum Category
{
    [Description("Lanche")]
    SANDWICH = 1,

    [Description("Sobremesa")]
    DESSERT = 2,

    [Description("Acompanhamento")]
    SIDEDISH = 3,

    [Description("Bebida")]
    BEVERAGE = 4,
}