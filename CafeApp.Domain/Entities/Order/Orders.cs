using System.Diagnostics.Metrics;

namespace CafeApp.Domain;

public class Orders
{
    public int Id { get; set; }


    public int CreatedByStaffId { get; set; } //FK
    public int TableSessionId { get; set; } //FK


    public DateTime CreatedTime { get; set; }



    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> OrderItems => _items.AsReadOnly();


    public OrderStatusEnum OrderStatus { get; set; }
    public OrderTypeEnum OrderType { get; set; }
}

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