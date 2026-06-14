using System.Xml.Linq;
using System;

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

//Invariants
//   Category name must be unique
//   Archived category cannot contain active MenuItems
//   Active MenuItem must belong to exactly one category

//Commands
//   CreateMenuItem
//   UpdatePrice
//   AddModification

//State
//Mostly static:
//   Active → Deprecated


//Events
//   MenuItemCreated
//   PriceUpdated