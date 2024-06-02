using Application;

var heap = new MinHeap();
int k, i, n = 6;
Console.WriteLine("Entered 6 keys:- 3, 10, 12, 8, 2, 14");

heap.Add(3);
heap.Add(10);
heap.Add(12);
heap.Add(8);
heap.Add(2);
heap.Add(14);

Console.WriteLine($"The current max element is {heap.Peek()}");

heap.Delete();
Console.WriteLine($"The current max element is {heap.Peek()}");
heap.Delete();
Console.WriteLine($"The current max element is {heap.Peek()}");
heap.Delete();
Console.WriteLine($"The current max element is {heap.Peek()}");
heap.Delete();
Console.WriteLine($"The current max element is {heap.Peek()}");
heap.Delete();
Console.WriteLine($"The current max element is {heap.Peek()}");
// heap.Delete();
// Console.WriteLine($"The current max element is {heap.Peek()}");