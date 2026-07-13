using System.Diagnostics.Metrics;

namespace CafeApp.Domain;

public class Order
    : IHasDomainEvents
{
    public int Id { get; private set; }


    public int CreatedByStaffId { get; private set; } //FK
    public int? TableSessionId { get; private set; } //FK


    public DateTime CreatedTime { get; private set; }



    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> OrderItems => _items.AsReadOnly();

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;


    public OrderStatusEnum OrderStatus { get; private set; }
    public OrderTypeEnum OrderType { get; private set; }

    private Order() { }

    #region Factory Method
    public static Order Create(
        int createdByStaffId, 
        OrderTypeEnum type, 
        int? tableSessionId = null)
    {
        var order = new Order
        {
            Id = default, // TODO - like Guid.NewGuid(), DB auto generated
            CreatedByStaffId = createdByStaffId,
            TableSessionId = tableSessionId,
            CreatedTime = DateTime.UtcNow,
            OrderStatus = OrderStatusEnum.Draft,
            OrderType = type
        };

        order.AddDomainEvent(new OrderCreated(order.Id, createdByStaffId));
        return order;
    }
    #endregion 

    #region Commands (Behavior)

    public void AddItem(int menuItemId, int quantity, decimal unitPrice)
    {
        EnsureCanModify();

        if (quantity <= 0)
            throw new InvalidOperationException("Quantity must be greater than zero.");

        var existing = _items.FirstOrDefault(x => x.MenuItemId == menuItemId);

        if (existing != null)
        {
            existing.Increase(quantity);
        }
        else
        {
            _items.Add(OrderItem.Create(this.Id, menuItemId, quantity, unitPrice));
        }

        AddDomainEvent(new OrderItemAdded(Id, menuItemId, quantity));
    }

    public void RemoveItem(int menuItemId)
    {
        EnsureCanModify();

        var item = _items.FirstOrDefault(x => x.MenuItemId == menuItemId);

        if (item == null)
            throw new InvalidOperationException("Item not found.");

        _items.Remove(item);

        AddDomainEvent(new OrderItemRemoved(Id, menuItemId));
    }

    public void Confirm()
    {
        EnsureCanModify();

        if (!_items.Any())
            throw new InvalidOperationException("Cannot confirm empty order.");

        OrderStatus = OrderStatusEnum.Confirmed;

        AddDomainEvent(new OrderConfirmed(Id));
    }

    public void Cancel(string reason)
    {
        if (OrderStatus == OrderStatusEnum.Completed)
            throw new InvalidOperationException("Cannot cancel completed order.");

        OrderStatus = OrderStatusEnum.Cancelled;

        AddDomainEvent(new OrderCancelled(Id, reason));
    }

    public void Complete()
    {
        if (OrderStatus != OrderStatusEnum.Confirmed)
            throw new InvalidOperationException("Only confirmed orders can be completed.");

        OrderStatus = OrderStatusEnum.Completed;

        AddDomainEvent(new OrderCompleted(Id));
    }

    #endregion

    #region Invariants

    private void EnsureCanModify()
    {
        if (OrderStatus == OrderStatusEnum.Cancelled)
            throw new InvalidOperationException("Order is cancelled.");

        if (OrderStatus == OrderStatusEnum.Completed)
            throw new InvalidOperationException("Order is completed.");
    }

    #endregion


    #region Domain Events

    private void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearEvents()
    {
        _domainEvents.Clear();
    }

    #endregion


}

#region Invariants-Aggrergate-Event-Handle

//Invariants:
//   Cannot add items if order is Closed
//   Cannot change items after Paid
//   Order must have at least 1 item before confirmation
//   Total = sum(items + modifications)


//Commands
//   CreateOrder
//   AddItem
//   RemoveItem
//   ConfirmOrder
//   CancelOrder

//State machine
//  Draft → Confirmed → Preparing → Served → Closed → Paid
//           ↘ Cancelled

//Domain events
//   OrderCreated
//   ItemAdded
//   OrderConfirmed
//   OrderCancelled
//   OrderCompleted
#endregion


public record OrderCreated(int OrderId, int CreatedByStaffId) : IDomainEvent;
public record OrderItemAdded(int OrderId, int MenuItemId, int Quantity) : IDomainEvent;
public record OrderItemRemoved(int OrderId, int MenuItemId) : IDomainEvent;
public record OrderConfirmed(int OrderId) : IDomainEvent;
public record OrderCancelled(int OrderId, string Reason) : IDomainEvent;
public record OrderCompleted(int OrderId) : IDomainEvent;