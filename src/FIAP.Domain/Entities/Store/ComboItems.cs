using FIAP.Domain.Entities.Base;

namespace FIAP.Domain.Entities.Store;

public class ComboItems : EntityBaseSoft<long>
{
    public static readonly int MIN_QUANTITY_ALLOWED = 1;
    public static readonly int MAX_QUANTITY_ALLOWED = 99;

    public long ProductId { get; private set; }
    public Products Product { get; private set; }

    public long ComboId { get; private set; }
    public Combos Combo { get; private set; }

    public int Quantity { get; private set; }

    protected ComboItems() { }

    public ComboItems(Products product, int quantity)
    {
        var validationResult = Validate(product, quantity);

        if (validationResult.IsInvalid())
            throw new ArgumentException(validationResult.GetErrorsMessage());

        Product = product;
        ProductId = product.Id;
        Quantity = quantity;
    }

    public decimal CalculateValue()
    {
        return Quantity * Product.Price;
    }

    public int CalculateTimeToPrepare()
    {
        return Product.TimeToPrepareMinutes * Quantity;
    }

    private DomainValidationResult Validate(Products product, int quantity)
    {
        var result = new DomainValidationResult();

        if (product == default)
            result.AddError("A ComboItem cannot exist without a product");

        if (quantity < MIN_QUANTITY_ALLOWED)
            result.AddError($"Quantity must be greater than or equal to {MIN_QUANTITY_ALLOWED}");

        if (quantity > MAX_QUANTITY_ALLOWED)
            result.AddError($"Quantity must be less than or equal to {MAX_QUANTITY_ALLOWED}");

        return result;
    }
}