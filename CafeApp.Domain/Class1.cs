namespace CafeApp.Domain;

public class Class1
{

}

public class Tables
{
    public int Id { get; set; }
    public int SeatsNumber { get; set; }
    public int Number { get; set; }
}
public class TableSession
{
    public int Id { get; set; }
    public int TableId { get; set; } //FK
    public int BookingId { get; set; } //FK
    public int ServedByStaffId { get; set; } //FK
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int PartySize { get; set; }
}

public class  Staff
{
    public int Id { get; set; }
    public string Name { get; set; }
}




public class Booking
{
    public int Id { get; set; }
    public int TableId { get; set; } //FK
    public int CustomerId { get; set; } //FK
    public DateTime ReservationTime { get; set; }
    public int PeopleNumber { get; set; }
}
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}



public class Order
{
    public int Id { get; set; }
    public int OrderStatusId { get; set; } //FK
    public int CreatedByStaffId { get; set; } //FK
    public int TableSessionId { get; set; } //FK
    public DateTime CreatedTime { get; set; }
    public int OrderTypeId { get; set; } //FK
}
public class OrderStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class OrderType
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class  OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; } //FK
    public int MenuItemId { get; set; } //FK
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

public class OrderItemModification
{
    public int OrderItemId { get; set; } //FK + PK
    public int ModificationId { get; set; } //FK + PK
    public decimal AdditionalCost { get; set; }
}



public class Payment
{ 
    public int Id { get; set; }
    public int BillId { get; set; } //FK
    public int CustomerId { get; set; } //FK
    public int PayStatusId { get; set; } //FK
    public decimal Amount { get; set; }
    public DateTime PaymentTime { get; set; }
    public int PayTypeId { get; set; } //FK

}

public class PayType
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class PayStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}



public class Bill
{
    public int Id { get; set; }
    public int OrderId { get; set; } //FK
    public int BillStatusId { get; set; } //FK
    public decimal TotalAmount { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime DeliveredTime { get; set; }
}

public class BillStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class BillAdjustment
{
    public int Id { get; set; }
    public int BillId { get; set; } //FK
    public decimal Amount { get; set; }
    public string Reason { get; set; }
}


public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal CurrentPrice { get; set; }
    public int MenuCategoryId { get; set; } //FK
}

public class MenuCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Modification
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal AdditionalCost { get; set; }
}
public class MenuItemModification
{
    public int MenuItemId { get; set; } //FK + PK
    public int ModificationId { get; set; } //FK + PK
}