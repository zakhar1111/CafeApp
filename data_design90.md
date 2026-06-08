Version 2 
9/10

<img width="1287" height="804" alt="image" src="https://github.com/user-attachments/assets/9084f453-4535-4743-8cd2-9a1a4bc2e3b1" />

## Relationship overview

- <img width="547" height="290" alt="image" src="https://github.com/user-attachments/assets/34f50133-f004-4c92-a86a-29eaeffcdbc0" />
- <img width="211" height="137" alt="image" src="https://github.com/user-attachments/assets/490d959a-fe06-4102-b632-60cfe1d7227b" />
- <img width="192" height="133" alt="image" src="https://github.com/user-attachments/assets/a5f92510-fb0a-4529-9fdc-be20a9204417" />
- <img width="328" height="142" alt="image" src="https://github.com/user-attachments/assets/126f06ef-d94c-4fc5-aa8d-d8edc0f35e3b" />
- <img width="280" height="131" alt="image" src="https://github.com/user-attachments/assets/5f5d1e13-c04f-4ea9-962c-b81d7a4d5192" />
- <img width="288" height="178" alt="image" src="https://github.com/user-attachments/assets/f5813115-04c3-4907-9e13-559e25b634fe" />

## Requirements coverage
This schema covers all listed requirements:

- ✅ Reservations
- ✅ Walk-in seating (via TableSession)
- ✅ Order tracking
- ✅ Multiple order items
- ✅ Item modifications
- ✅ Bill generation
- ✅ Bill delivery
- ✅ Bill adjustments
- ✅ Split payments
- ✅ Staff actions
- ✅ Historical price preservation
- ✅ Table occupancy lifecycle tracking.

## fixes for solid design
The only structural change for solid design production-ready is:
```
Bills
(
    Id PK,
    Order_id UNIQUE
)
```
and
```
Orders.TableSession_id NULL
```
for takeout orders.

