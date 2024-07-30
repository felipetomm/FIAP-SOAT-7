using FIAP.Domain.Entities.Base;
using FIAP.Domain.Entities.Enums;
using FIAP.Infrastructure.CrossCutting.Extensions;

namespace FIAP.Domain.Entities.Store;

public class Orders : EntityBaseSoft<long>
{
    public decimal OrderValue { get; private set; }
    public long CustomerId { get; private set; }
    public Customers Customer { get; set; }
    public OrderStatus Status { get; private set; }
    public int TimeEstimate { get; private set; }

    public List<Combos> Combos { get; set; }

    protected Orders() { }

    public Orders(List<Combos> combos)
    {
        Combos = combos;
        Status = OrderStatus.RECEIVED;
        OrderValue = decimal.Zero;

        Validate();
        CalculateValue();
        CalculateTimeEstimate();
    }

    public Orders(List<Combos> combos, Customers customer)
    {
        Combos = combos;
        Customer = customer;
        CustomerId = customer.Id;
        Status = OrderStatus.RECEIVED;
        OrderValue = decimal.Zero;

        Validate();
        CalculateValue();
        CalculateTimeEstimate();
    }

    public Orders(List<Combos> combos, Customers customer, OrderStatus status)
    {
        Combos = combos;
        Customer = customer;
        CustomerId = customer.Id;
        Status = status;
        OrderValue = decimal.Zero;

        Validate();
        CalculateValue();
        CalculateTimeEstimate();
    }

    public void NextOrderStatus(OrderStatus nextStatus)
    {
        var validationMessage = "";
        if (Status == OrderStatus.RECEIVED && nextStatus != OrderStatus.SENT_TO_KITCHEN)
            validationMessage = $"When order status is \"{Status}\" the new status can be \"{OrderStatus.SENT_TO_KITCHEN}\"";
        else if (Status == OrderStatus.SENT_TO_KITCHEN && nextStatus != OrderStatus.IN_PREPARATION && nextStatus != OrderStatus.REJECTED)
            validationMessage = $"When order status is \"{Status}\" the new status can be \"{OrderStatus.IN_PREPARATION}\" or \"{OrderStatus.REJECTED}\"";
        else if (Status == OrderStatus.FINISHED)
            validationMessage = $"When order status is \"{Status}\" the status can't be changed";
        else if (Status == OrderStatus.IN_PREPARATION && nextStatus != OrderStatus.READY)
            validationMessage = $"When order status is \"{Status}\" the new status can be \"{OrderStatus.READY}\"";
        else if (Status == OrderStatus.READY && nextStatus != OrderStatus.FINISHED)
            validationMessage = $"When order status is \"{Status}\" the new status can be \"{OrderStatus.FINISHED}\"";

        if (!validationMessage.IsEmpty())
        {
            var domainValidationResult = new DomainValidationResult();
            domainValidationResult.AddError(validationMessage);
            throw new ArgumentException(domainValidationResult.GetErrorsMessage());
        }

        Status = nextStatus;
    }


    private void Validate()
    {
        if (!Combos?.Any() ?? false)
        {
            var domainValidationResult = new DomainValidationResult();
            domainValidationResult.AddError("An order must have at least one combo");
            throw new ArgumentException(domainValidationResult.GetErrorsMessage());
        }
        if (Customer == default)
        {
            var domainValidationResult = new DomainValidationResult();
            domainValidationResult.AddError("An order must have a customer");
            throw new ArgumentException(domainValidationResult.GetErrorsMessage());
        }
    }

    private void CalculateValue()
    {
        foreach (var combo in Combos)
        {
            OrderValue += combo.CalculateValue();
        }
    }

    private void CalculateTimeEstimate()
    {
        foreach (var combo in Combos)
        {
            TimeEstimate += combo.CalculateTimeToPrepare();
        }
    }
}