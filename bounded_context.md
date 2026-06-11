# Bound context decomposition 
- **Auth** - manages authentication and authorization for both customers and staff, including login credentials, roles, and permissions.
```
Auth Context
 ├─ Customer Accounts
 ├─ Staff Accounts
 └─ Roles & Permissions
```
- **Restaurant** - contains the core business logic such as bookings, table sessions, orders, menu items, bills, and restaurant operations.
```
Restaurant Context
 ├─ Booking
 ├─ TableSession
 ├─ Order
 ├─ Menu
 └─ Bill
```
- **Payment** - is responsible for payment transactions, payment methods, refunds, and communication with external payment providers.
```
Payment Context
 ├─ Payment
 ├─ Refund
 └─ Payment Provider Integration
```
- **Notification** - responsible for sending emails, SMS messages, booking confirmations, and payment receipts.
```
Notification Context (future)
 ├─ Email
 ├─ SMS
 └─ Push Notifications
```
- **Inventory** - could manage ingredients, stock levels, supplier orders, and menu availability without coupling inventory rules to ordering and billing logic.
```
Inventory Context (future)
 ├─ Ingredients
 ├─ Stock
 └─ Suppliers
```
