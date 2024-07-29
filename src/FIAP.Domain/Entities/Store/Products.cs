using FIAP.Domain.Entities.Base;
using FIAP.Domain.Entities.Enums;
using FIAP.Infrastructure.CrossCutting.Extensions;

namespace FIAP.Domain.Entities.Store;

public class Products : EntityBaseSoft<long>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public Category Category { get; private set; }
    public int TimeToPrepareMinutes { get; private set; }

    protected Products() { }

    public Products(
        long id,
        string name,
        string description,
        decimal price,
        int quantity,
        Category category,
        int timeToPrepareMinutes
    )
    {
        var validation = Validate(
            name: name,
            price: price,
            quantity: quantity,
            category: category,
            timeToPrepareMinutes: timeToPrepareMinutes
        );

        if (!validation.IsValid())
            throw new ArgumentException(validation.GetErrorsMessage());

        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        Category = category;
        TimeToPrepareMinutes = timeToPrepareMinutes;
        Created = DateTime.UtcNow;
        Deleted = false;
        Hash = Guid.NewGuid();
    }

    private DomainValidationResult Validate(
        string name,
        decimal price,
        int quantity,
        Category category,
        int timeToPrepareMinutes
    )
    {
        var validationResult = new DomainValidationResult();

        if (price < 0)
            validationResult.AddError("Price can't be lower than \"0.00\".");

        if (quantity < 0)
            validationResult.AddError("Quantity can't be lower than \"0\".");

        if (name.IsEmpty())
            validationResult.AddError("Name can't be null or empty.");

        if (category == default)
            validationResult.AddError("Invalid Category");

        if (timeToPrepareMinutes < 0)
            validationResult.AddError("Time can't be lower than \"0\".");

        return validationResult;
    }
}