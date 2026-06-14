namespace CafeApp.Domain;

public class MenuItem
{
    public int Id { get; set; }

    public int MenuCategoryId { get; set; } //FK


    public string Name { get; set; }
    public decimal CurrentPrice { get; set; }
    



    private readonly List<MenuItemModification> _allowedModifications = new();

    public IReadOnlyCollection<MenuItemModification>
        AllowedModifications => _allowedModifications.AsReadOnly();
}
