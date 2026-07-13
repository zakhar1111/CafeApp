using System;

namespace CafeApp.Domain;

public class TableSession
    : IHasDomainEvents
{
    private TableSession() { }
    public int Id { get; private set; }

    public int TableId { get; private set; } //FK
    public int? BookingId { get; private set; } //FK
    public int ServedByStaffId { get; private set; } //FK
    

    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    

    public int PartySize { get; private set; }
    public TableSessionStatusEnum Status { get; private set; }

    #region Factory
    public static TableSession Start(
        int tableId,
        int servedByStaffId,
        int partySize,
        int? bookingId = null)
    {
        if (partySize <= 0)
            throw new InvalidOperationException();

        var session = new TableSession
        {
            TableId = tableId,
            ServedByStaffId = servedByStaffId,
            BookingId = bookingId,
            PartySize = partySize,
            StartTime = DateTime.UtcNow,
            Status = TableSessionStatusEnum.Active
        };

        session.AddDomainEvent(
            new TableSessionStarted(session.Id,tableId));

        return session;
    }
    #endregion

    #region Command (Behavior)
    public void End()
    {
        if (Status == TableSessionStatusEnum.Ended)
            throw new InvalidOperationException();

        EndTime = DateTime.UtcNow;

        Status = TableSessionStatusEnum.Ended;

        AddDomainEvent(new TableSessionEnded(Id));
    }
    public void AssignBooking(int bookingId)
    {
        if (Status == TableSessionStatusEnum.Ended)
            throw new InvalidOperationException();

        if (BookingId != null)
            throw new InvalidOperationException();

        BookingId = bookingId;

        AddDomainEvent(
            new BookingAssignedToSession(Id,bookingId));
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
}
//Invariants:
//   EndTime must be after StartTime
//   Cannot start session if table is occupied
//   Session must link to either Booking OR walk-in, not both null
//PartySize > 0
//TableId must exist
//ServedByStaffId must exist

//Commands
//   StartSession
//   AssignBooking
//   EndSession

//State machine
//   Active → Ended

//Events
//   TableSessionStarted
//   TableAssigned
//   SessionEnded

public record TableSessionStarted(int SessionId,int TableId)
    : IDomainEvent;

public record BookingAssignedToSession(int SessionId,int BookingId)
    : IDomainEvent;

public record TableSessionEnded(int SessionId)
    : IDomainEvent;


//Typical Flow
//Customer arrives
//      ↓
//TableSession.Start()
//      ↓
//TableSessionStarted
//      ↓
//Order created
//      ↓
//Bill generated
//      ↓
//Session.End()
//      ↓
//TableSessionEnded