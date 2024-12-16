# Document

## Functor

### 1. Comparetor

> namespace:
>
> ​	Better.Functor

`bool delegete Comparator(T , T )`

> define the Comparetor used in compare

## Container

### 1. priority_queue

> namespace:
>
> ​	Better.Container

1. `Priority_Queue<T>`

2. Constructor

   1. `Priority_Queue(Comparetor)`

3. Function

   1. ` void Insert(T)`

   > insert a value into priority_queue which is sorted by Comparetor

   2. `T Pop()`

   > return the root node of the heap and then pop it from the heap.

   3. `T Top()`

   > return the root node of the heap.

   4. `InsertArray(List<T>)`

   > Insert a list into heap.
   
   5. ` bool IsEmpty()`
   
   > Check the heap is empty or not