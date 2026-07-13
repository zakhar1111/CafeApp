namespace CafeApp.Domain;

public class Booking 
    : IHasDomainEvents
{
    private Booking() { }
    public int Id { get; private set; }


    public int? TableId { get; private set; } //FK
    public int CustomerId { get; private set; } //FK
    

    public BookingStatusEnum BookingState { get; private set; } 


    public DateTime ReservationTime { get; private set; }
    public int PeopleNumber { get; private set; }

    #region Factory Method
    public static Booking Create(int customerId,DateTime reservationTime,int peopleNumber)
    {
        if (peopleNumber <= 0)
            throw new InvalidOperationException(
                "Party size must be positive.");

        if (reservationTime <= DateTime.UtcNow)
            throw new InvalidOperationException(
                "Reservation must be in future.");

        var booking = new Booking
        {
            CustomerId = customerId,
            ReservationTime = reservationTime,
            PeopleNumber = peopleNumber,
            BookingState = BookingStatusEnum.Pending
        };

        booking.AddDomainEvent(
            new BookingCreated(
                booking.Id,
                customerId));

        return booking;
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
    public void AssignTable(int tableId)
    {
        EnsureNotFinished();

        TableId = tableId;

        AddDomainEvent(
            new TableAssignedToBooking(
                Id,
                tableId));
    }


    public void Confirm()
    {
        if (BookingState != BookingStatusEnum.Pending)
            throw new InvalidOperationException(
                "Only pending booking can be confirmed.");

        BookingState = BookingStatusEnum.Confirmed;

        AddDomainEvent(
            new BookingConfirmed(Id));
    }

    public void Cancel(string reason)
    {
        if (BookingState == BookingStatusEnum.Completed)
            throw new InvalidOperationException(
                "Completed booking cannot be cancelled.");

        if (BookingState == BookingStatusEnum.Cancelled)
            return;

        BookingState = BookingStatusEnum.Cancelled;

        AddDomainEvent(
            new BookingCancelled(
                Id,
                reason));
    }

    public void SeatCustomer()
    {
        if (BookingState != BookingStatusEnum.Confirmed)
            throw new InvalidOperationException(
                "Only confirmed booking can be seated.");

        if (TableId == null)
            throw new InvalidOperationException(
                "Table must be assigned.");

        BookingState = BookingStatusEnum.Seated;

        AddDomainEvent(
            new CustomerSeated(Id));
    }

    public void Complete()
    {
        if (BookingState != BookingStatusEnum.Seated)
            throw new InvalidOperationException(
                "Only seated booking can complete.");

        BookingState = BookingStatusEnum.Completed;

        AddDomainEvent(
            new BookingCompleted(Id));
    }
    #endregion

    #region INVARIANTS
    private void EnsureNotFinished()
    {
        if (BookingState == BookingStatusEnum.Cancelled ||
            BookingState == BookingStatusEnum.Completed)
            throw new InvalidOperationException(
                "Cannot modify a finished booking.");
    }
    #endregion
}
//Invariants:
//   Cannot double-book same table/time slot
//   PeopleNumber must be > 0
//   Cannot confirm past reservation time

//Commands
//   CreateBooking
//   ConfirmBooking
//   CancelBooking

//State machine
//   Pending → Confirmed → Seated → Completed
//           ↘ Cancelled

//Events
//   BookingCreated
//   BookingConfirmed
//   BookingCancelled

public record BookingCreated(int BookingId,int CustomerId)
    : IDomainEvent;

public record BookingConfirmed(int BookingId)
    : IDomainEvent;

public record TableAssignedToBooking(int BookingId,int TableId)
    : IDomainEvent;

public record BookingCancelled(int BookingId,string Reason)
    : IDomainEvent;

public record CustomerSeated(int BookingId)
    : IDomainEvent;

public record BookingCompleted(int BookingId)
    : IDomainEvent;