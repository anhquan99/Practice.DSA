using Application;

MaxHeap heap = new MaxHeap(15);
int k, i, n = 6;
Console.WriteLine("Entered 6 keys:- 3, 10, 12, 8, 2, 14");

heap.InsertKey(3);
heap.InsertKey(10);
heap.InsertKey(12);
heap.InsertKey(8);
heap.InsertKey(2);
heap.InsertKey(14);

Console.WriteLine($"The current size of the heap is {heap.CurrentSize()}");
Console.WriteLine($"The current maximum element is {heap.GetMax()}");

heap.DeleteKey(2);
Console.WriteLine($"The current size of the heap is {heap.CurrentSize()}");

heap.InsertKey(15);
heap.InsertKey(5);
Console.WriteLine($"The current size of the heap is {heap.CurrentSize()}");
Console.WriteLine($"The current maximum element is {heap.GetMax()}");