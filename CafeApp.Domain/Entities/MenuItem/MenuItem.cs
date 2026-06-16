using System.Xml.Linq;
using System;

namespace CafeApp.Domain;

public class MenuItem
{
    private MenuItem() { }
    public int Id { get; private set; }

    public int MenuCategoryId { get; private set; } //FK


    public string Name { get; private set; }
    public decimal CurrentPrice { get; private set; }
    
    public MenuItemStatusEnum MenuItemStatus { get; private set; }


    private readonly List<MenuItemModification> _allowedModifications = new();

    public IReadOnlyCollection<MenuItemModification>
        AllowedModifications => _allowedModifications.AsReadOnly();

    #region Factory Method
    public static MenuItem Create(
        string name,
        decimal price,
        int categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException();

        if (price < 0)
            throw new InvalidOperationException();

        var item = new MenuItem
        {
            Name = name,
            CurrentPrice = price,
            MenuCategoryId = categoryId,
            MenuItemStatus = MenuItemStatusEnum.Active
        };

        item.AddDomainEvent(
            new MenuItemCreated(item.Id));

        return item;
    }
    #endregion
    #region Commands (Behavior)
    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0)
            throw new InvalidOperationException();
        if (CurrentPrice == newPrice)
            return;

        CurrentPrice = newPrice;

        AddDomainEvent(
            new MenuItemPriceChanged(Id,newPrice));
    }
    public void Deactivate()
    {
        MenuItemStatus = MenuItemStatusEnum.Inactive;

        AddDomainEvent(new MenuItemDeactivated(Id));
    }

    public void Activate()
    {
        MenuItemStatus = MenuItemStatusEnum.Active;

        AddDomainEvent(new MenuItemActivated(Id));
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

public record MenuItemCreated(int MenuItemId)
    : IDomainEvent;

public record MenuItemPriceChanged(int MenuItemId,decimal NewPrice)
    : IDomainEvent;

public record MenuItemActivated(int MenuItemId)
    : IDomainEvent;

public record MenuItemDeactivated(int MenuItemId)
    : IDomainEvent;

public enum MenuItemStatusEnum
{
    Active = 1,
    Inactive = 2
}