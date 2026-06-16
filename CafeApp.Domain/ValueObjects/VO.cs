namespace CafeApp.Domain;


public readonly record struct CustomerId(int Value);


public readonly record struct StaffId(int Value);


public readonly record struct BillId(int Value);
public readonly record struct BillAdjustmentId(int Value);
public readonly record struct PaymentId(int Value);


public readonly record struct BookingId(int Value);


public readonly record struct OrderId(int Value);
public readonly record struct OrderItemId(int Value);
public readonly record struct OrderItemModificationId(int Value);


public readonly record struct TableId(int Value);
public readonly record struct TableSessionId(int Value);
