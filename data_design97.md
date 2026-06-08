## version 3 
9.7/10

<img width="1315" height="761" alt="image" src="https://github.com/user-attachments/assets/6b850c59-c4c1-4cc3-9411-cf29515de2d3" />

## DDD Aggregate Assessment

Your aggregates are now very clean.

- Booking Aggregate ```Booking```

- Table Session Aggregate ```TableSession```
- Order Aggregate
```
Order
 ├── OrderItem
 └── OrderItemModification
```
- Bill Aggregate
```
Bill
 ├── BillAdjustment
 └── Payment
```
- Menu Aggregate
```
MenuCategory
 ├── MenuItem
 ├── MenuItemModification
 └── Modification
```

## Requirements Grow
- Kitchen workflow - for preparation tracking.
```
KitchenTicket
KitchenTicketItem
```
- Split bills - for advanced restaurants.
```
Bill
    1 → many Orders

or

Bill
    1 → many Customers
```
- Audit columns - on transactional tables.
```
CreatedAt
UpdatedAt
```
