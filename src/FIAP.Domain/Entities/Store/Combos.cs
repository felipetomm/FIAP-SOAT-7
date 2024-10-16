using FIAP.Domain.Entities.Base;
using FIAP.Domain.Entities.Enums;

namespace FIAP.Domain.Entities.Store;

public class Combos : EntityBaseSoft<long>
{
    public List<ComboItems> Items { get; set; }

    public long OrderId { get; set; }
    public Orders Order { get; set; }

    protected Combos() { }

    public Combos(List<ComboItems> items)
    {
        var validationResult = Validate(items);

        if (validationResult.IsInvalid())
            throw new ArgumentException(validationResult.GetErrorsMessage());

        Items = items;
    }

    public decimal CalculateValue()
    {
        return Items.Sum(x => x.CalculateValue());
    }

    public int CalculateTimeToPrepare()
    {
        return Items.Sum(x => x.CalculateTimeToPrepare());
    }

    private DomainValidationResult Validate(List<ComboItems> items)
    {
        var result = new DomainValidationResult();

        if (!items?.Any() ?? false)
            result.AddError("A Combo cannot exist without items");

        var duplicatedCategories = GetDuplicatedProductCategories(items);

        if (duplicatedCategories.Count != 0)
            result.AddError("A Combo cannot have duplicated categories");

        return result;
    }

    private List<Category> GetDuplicatedProductCategories(List<ComboItems> items)
    {
        return items.GroupBy(x =>
            x.Product.Category
        )
        .Select(s => new
        {
            s.Key,
            Total = s.Count()
        })
        .Where(w => w.Total > 1)
        .Select(s => s.Key)
        .ToList();
    }
}