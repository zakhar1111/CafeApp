namespace CafeApp.Domain;

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
