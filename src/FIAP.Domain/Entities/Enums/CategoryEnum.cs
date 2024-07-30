using System.ComponentModel;

using FIAP.Infrastructure.CrossCutting.Attributes;

namespace FIAP.Domain.Entities.Enums;

public enum Category
{
    [Description("Lanche")]
    [AlternateValue("SANDWICH")]
    SANDWICH = 1,

    [Description("Sobremesa")]
    [AlternateValue("DESSERT")]
    DESSERT = 2,

    [Description("Acompanhamento")]
    [AlternateValue("SIDEDISH")]
    SIDEDISH = 3,

    [Description("Bebida")]
    [AlternateValue("BEVERAGE")]
    BEVERAGE = 4,
}