using System.Runtime.ConstrainedExecution;

namespace CafeApp.Domain;

public class Bill
{
    private Bill() { }
    public int Id { get; private set; }


    public int OrderId { get; private set; } //FK


    public decimal TotalAmount => 
        BaseAmount + Adjustments.Sum(x => x.Amount) - Payments.Sum(x => x.Amount);
    public decimal BaseAmount { get; private set; }
    public decimal PaidAmount { get; private set; }

    public DateTime CreatedTime { get; private set; }
    public DateTime? DeliveredTime { get; private set; }



    public BillStatusEnum BillStatus { get; private set; }

    private readonly List<BillAdjustment> _adjustments = new();
    public IReadOnlyCollection<BillAdjustment> Adjustments
        => _adjustments.AsReadOnly();

    private readonly List<Payment> _payments = new(); 
    public IReadOnlyCollection<Payment> Payments 
        => _payments.AsReadOnly();

    #region Factory Method
    public static Bill Create(int orderId,decimal baseAmount)
    {
        if (baseAmount < 0)
            throw new InvalidOperationException();

        var bill = new Bill
        {
            OrderId = orderId,
            BaseAmount = baseAmount,
            CreatedTime = DateTime.UtcNow,
            BillStatus = BillStatusEnum.Generated
        };

        bill.AddDomainEvent(
            new BillGenerated(
                bill.Id,
                orderId,
                baseAmount));

        return bill;
    }
    #endregion

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

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

    #region Commands (Behavior)
    public void AddAdjustment(decimal amount,string reason)
    {
        EnsureNotClosed();
        EnsureNotPaid();

        var adjustment =
            BillAdjustment.Create(
                amount,
                reason);

        _adjustments.Add(adjustment);

        if (TotalAmount < 0)
            throw new InvalidOperationException(
                "Bill cannot become negative.");

        AddDomainEvent(
            new BillAdjustmentAdded(
                Id,
                amount,
                reason));
    }
    public void RegisterPayment(decimal amount)
    {
        EnsureNotClosed();

        if (amount <= 0)
            throw new InvalidOperationException();

        if (PaidAmount + amount > TotalAmount)
            throw new InvalidOperationException(
                "Overpayment not allowed.");

        PaidAmount += amount;

        AddDomainEvent(
            new BillPaymentReceived(
                Id,
                amount));

        if (PaidAmount == TotalAmount)
        {
            BillStatus = BillStatusEnum.Paid;

            AddDomainEvent(
                new BillPaid(Id));
        }
        else
        {
            BillStatus = BillStatusEnum.PartiallyPaid;
        }
    }
    
    public void Close()
    {
        if (BillStatus != BillStatusEnum.Paid)
            throw new InvalidOperationException(
                "Only paid bills can be closed.");

        BillStatus = BillStatusEnum.Closed;

        DeliveredTime = DateTime.UtcNow;

        AddDomainEvent(new BillClosed(Id));
    }
    #endregion

    #region Invariants

    private void EnsureNotClosed()
    {
        if (BillStatus == BillStatusEnum.Closed)
            throw new InvalidOperationException("Bill is already Closed.");

    }
    private void EnsureNotPaid()
    {
        if (BillStatus == BillStatusEnum.Paid)
            throw new InvalidOperationException("Bill is already Paid.");
    }

    #endregion
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

public record BillGenerated(int BillId,int OrderId,decimal Amount) 
    : IDomainEvent;

public record BillAdjustmentAdded(int BillId,decimal Amount,string Reason) 
    : IDomainEvent;

public record BillPaymentReceived(int BillId, decimal Amount) 
    : IDomainEvent;

public record BillPaid(int BillId) : IDomainEvent;

public record BillClosed(int BillId) : IDomainEvent;