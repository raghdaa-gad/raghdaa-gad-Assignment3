# Stack & Heap

## Diagram 1

STACK                         HEAP
+-------------+              +----------------------+
| o1          |              | Order object         |
| address ────────────────→  | OrderId = 1          |
+-------------+              | CustomerName = "Ali" |
                             | IsPaid = false       |
                             +----------------------+

## Diagram 2

STACK                         HEAP
+-------------+              +----------------------+
| o1          |──────────┐   | Order object         |
| address     |          │   | OrderId = 1          |
+-------------+          ├──→| CustomerName = "Ali" |
| o2          |──────────┘   | IsPaid = false       |
| same address o1|            +----------------------+
+-------------+


## Diagram 3



STACK                         HEAP
+-------------+              +----------------------+
| o1          |──────────┐   | Order object         |
| address     |          │   | OrderId = 1          |
+-------------+          ├──→| CustomerName = "Ali" |
| o2          |──────────┘   | IsPaid = true (UPDATE)      |
| same address o1|            +----------------------+
+-------------+

## What would be different with structs?

1-If Order were a struct o2 = o1 would copy the values instead of the reference
Like Point in Part C o1 and o2 would have separate copies
2-Changing o2 would not change o1