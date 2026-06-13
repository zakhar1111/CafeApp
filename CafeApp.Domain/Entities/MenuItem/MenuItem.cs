namespace CafeApp.Domain;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal CurrentPrice { get; set; }
    public int MenuCategoryId { get; set; } //FK
}
