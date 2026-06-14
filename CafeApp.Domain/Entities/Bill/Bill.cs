using System.Runtime.ConstrainedExecution;

namespace CafeApp.Domain;

public class Bill
{
    public int Id { get; set; }


    public int OrderId { get; set; } //FK


    public decimal TotalAmount { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime DeliveredTime { get; set; }



    public BillStatusEnum BillStatus { get; set; }

    private readonly List<BillAdjustment> _adjustments = new();
    public IReadOnlyCollection<BillAdjustment> Adjustments
        => _adjustments.AsReadOnly();

    private readonly List<Payment> _payments = new(); 
    public IReadOnlyCollection<Payment> Payments 
        => _payments.AsReadOnly();
}

//Invariants:
//   Cannot be paid twice
//   Total must equal sum of order snapshot
//   Adjustments cannot make total negative
//   Bill must be generated only once per order

//Commands
//   GenerateBill
//   AddAdjustment
//   MarkAsPaid

//State machine
//   Pending → Generated → Paid → Closed

//Domain events
//   BillGenerated
//   BillAdjusted
//   PaymentReceived