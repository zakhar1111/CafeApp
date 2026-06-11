The use cases are grouped around **aggregate roots**, for later commands, handlers, repository, state machine, and domain events.

# Booking Aggregate

## Purpose

Manage table reservations before customers arrive.

### Use Cases

#### Create Booking

Customer reserves a table for a future date and time.

Flow:

```
Customer
    ↓
Create Booking
    ↓
Validate date/time
    ↓
Validate party size
    ↓
Create Booking(Pending)
```

#### Confirm Booking

Staff confirms reservation.

Flow:

```
Booking(Pending)
    ↓
Confirm
    ↓
Booking(Confirmed)
```

#### Cancel Booking

Customer or staff cancels reservation.

Flow:

```
Booking(Pending/Confirmed)
    ↓
Cancel
    ↓
Booking(Cancelled)
```

#### Mark No Show

Customer does not arrive.

Flow:

```
Booking(Confirmed)
    ↓
Reservation time passed
    ↓
Mark No Show
```

#### Seat Customer

Customer arrives and is assigned to a table session.

Flow:

```
Booking(Confirmed)
    ↓
Customer arrives
    ↓
Create TableSession
    ↓
Booking(Seated)
```

# TableSession Aggregate

## Purpose

Represents actual table occupancy.

### Use Cases

#### Open Table Session

Customer starts dining.

Flow:

```
Customer arrives
    ↓
Assign table
    ↓
Open Session
```

#### Transfer Table

Move customers to another table.

Flow:

```
Active Session
    ↓
Change Table
    ↓
Update Session
```

#### Add Orders To Session

Associate orders with dining session.

Flow:

```
Active Session
    ↓
Create Order
    ↓
Attach Order
```

#### Close Session

Customers leave restaurant.

Flow:

```
Session Active
    ↓
Bill Paid
    ↓
Close Session
```

# Order Aggregate

## Purpose

Manage food ordering lifecycle.

### Use Cases

#### Create Order

Waiter starts order.

Flow:

```
Active Session
    ↓
Create Order(Draft)
```

#### Add Item

Add menu item.

Flow:

```
Order(Draft)
    ↓
Add Item
    ↓
Recalculate Total
```

#### Remove Item

Flow:

```
Order(Draft)
    ↓
Remove Item
    ↓
Recalculate Total
```

#### Add Modification

Example:

```
Extra Cheese
No Onion
Medium Rare
```

Flow:

```
OrderItem
    ↓
Add Modification
```

#### Submit Order

Send to kitchen.

Flow:

```
Order(Draft)
    ↓
Submit
    ↓
Order(Submitted)
```

#### Start Preparation

Kitchen accepts order.

Flow:

```
Submitted
    ↓
Preparing
```

#### Mark Ready

Kitchen finishes cooking.

Flow:

```
Preparing
    ↓
Ready
```

#### Serve Order

Waiter serves food.

Flow:

```
Ready
    ↓
Served
```

#### Cancel Order

Allowed before preparation starts.

Flow:

```
Draft/Submitted
    ↓
Cancel
```

# Bill Aggregate

## Purpose

Manage billing process.

### Use Cases

#### Generate Bill

Create bill from orders.

Flow:

```
Served Orders
    ↓
Generate Bill
    ↓
Bill(Draft)
```

#### Add Adjustment

Examples:

```
Discount
Promotion
Service Charge
Compensation
```

Flow:

```
Bill
    ↓
Apply Adjustment
    ↓
Recalculate Total
```

#### Issue Bill

Send bill to customer.

Flow:

```
Bill(Draft)
    ↓
Issue
    ↓
Bill(Issued)
```

#### Mark Partially Paid

Split payment scenario.

Flow:

```
Bill(Issued)
    ↓
Partial Payment
    ↓
Bill(PartiallyPaid)
```

#### Mark Paid

All payments received.

Flow:

```
Bill(Issued/PartiallyPaid)
    ↓
Payment Completed
    ↓
Bill(Paid)
```

#### Void Bill

Mistake or cancellation.

Flow:

```
Bill(Issued)
    ↓
Void
    ↓
Bill(Voided)
```

# Payment Aggregate

## Purpose

Track financial transactions.

### Use Cases

#### Create Payment

Customer initiates payment.

Flow:

```
Bill(Issued)
    ↓
Create Payment
```

#### Authorize Payment

Payment provider approves transaction.

Flow:

```
Payment(Pending)
    ↓
Authorize
```

#### Capture Payment

Finalize payment.

Flow:

```
Authorized
    ↓
Capture
    ↓
Completed
```

#### Fail Payment

Flow:

```
Pending
    ↓
Failed
```

#### Refund Payment

Flow:

```
Completed
    ↓
Refund
    ↓
Refunded
```

# MenuCategory Aggregate (or Reference Data)

Usually not a true aggregate.

## Purpose

Manage restaurant menu structure.

### Use Cases

#### Create Category

```
Create Appetizers
Create Drinks
Create Desserts
```

Flow:

```
Staff
    ↓
Create Category
```

#### Rename Category

Flow:

```
Category
    ↓
Rename
```

#### Activate Category

Flow:

```
Inactive
    ↓
Active
```

#### Deactivate Category

Flow:

```
Active
    ↓
Inactive
```

# Aggregate Interaction Flow

The main restaurant workflow is:

```
Booking
    ↓
Seat Customer
    ↓
TableSession
    ↓
Create Order
    ↓
Submit Order
    ↓
Prepare Order
    ↓
Serve Order
    ↓
Generate Bill
    ↓
Create Payment
    ↓
Bill Paid
    ↓
Close Session
```

This flow is what should drive your next design steps:

```text
State Machines
    ↓
Aggregates
    ↓
Domain Events
    ↓
Commands
    ↓
CQRS Handlers
    ↓
API Endpoints
```

because every command, event, and endpoint can be directly derived from these use cases.
