namespace FIAP.Application.InputModels;

public class CreateOrderModel
{
    public List<ComboModel> MappedCombos { get; set; }
    public long CustomerId { get; set; }

    public class ComboModel
    {
        public List<ComboItemModel> Items { get; set; }

        public class ComboItemModel
        {
            public long ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}