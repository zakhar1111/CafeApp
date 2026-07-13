namespace CafeApp.Domain;

public class MenuItemModification
{
    private MenuItemModification()
    {
    }
    public int MenuItemId { get; private set; } //FK + PK
    public int ModificationId { get; private set; } //FK + PK

    #region Factory
    public static MenuItemModification Create(
        int menuItemId,
        int modificationId)
    {

        return new MenuItemModification
        {
            MenuItemId = menuItemId,
            ModificationId = modificationId
        };
    }
    #endregion
}