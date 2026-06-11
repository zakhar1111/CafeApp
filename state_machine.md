| Aggregate    | Suggested States                                              |
| ------------ | ------------------------------------------------------------- |
| Booking      | Pending, Confirmed, Seated, Completed, Cancelled, NoShow      |
| TableSession | Opened, Active, Closed, Cancelled                             |
| Order        | Draft, Submitted, Preparing, Ready, Served, Closed, Cancelled |
| Bill         | Draft, Issued, PartiallyPaid, Paid, Voided                    |
| MenuCategory | Active, Inactive (**optional**)                               |

## Booking
```
Pending
 ├─ Confirm → Confirmed
 └─ Cancel → Cancelled

Confirmed
 ├─ SeatGuest → Seated
 ├─ Cancel → Cancelled
 └─ MarkNoShow → NoShow

Seated
 └─ FinishVisit → Completed
```
## TableSassion
```
Opened
 ├─ StartService → Active
 └─ Cancel → Cancelled

Active
 └─ CloseSession → Closed
```
## Order
```
Draft
 ├─ Submit → Submitted
 └─ Cancel → Cancelled

Submitted
 ├─ StartPreparation → Preparing
 └─ Cancel → Cancelled

Preparing
 └─ MarkReady → Ready

Ready
 └─ Serve → Served

Served
 └─ Close → Closed
```
## Bill
```
Draft
 └─ Issue → Issued

Issued
 ├─ ReceivePartialPayment → PartiallyPaid
 ├─ ReceiveFullPayment → Paid
 └─ Void → Voided

PartiallyPaid
 ├─ ReceivePayment → Paid
 └─ Void → Voided
```
## MenuCategory
