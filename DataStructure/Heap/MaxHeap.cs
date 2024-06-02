namespace Application;
public class MaxHeap
{
    List<int> _arr;
    int _heapSize;
    public MaxHeap()
    {
        _arr = new List<int>();
        _heapSize = 0;
    }
    int LeftChild(int n) => 2 * n + 1;
    int RightChild(int n) => 2 * n + 2;
    int Parent(int n) => (n - 1) / 2;
    bool HasLeftChild(int n) => LeftChild(n) < _heapSize;
    bool HasRightChild(int n) => RightChild(n) < _heapSize;
    bool HasParent(int n) => Parent(n) >= 0;
    void Swap(int a, int b)
    {
        var temp = _arr[a];
        _arr[a] = _arr[b];
        _arr[b] = temp;
    }
    void HeapifyDown()
    {
        var index = 0;
        while (HasLeftChild(index))
        {
            var largest = LeftChild(index);
            if (HasRightChild(index) && _arr[LeftChild(index)] < _arr[RightChild(index)])
            {
                largest = RightChild(index);
            }
            if (_arr[index] > _arr[largest])
            {
                break;
            }
            else
            {
                Swap(index, largest);
            }
            index = largest;
        }
    }
    void HeapifyUp()
    {
        var index = _heapSize - 1;
        while (HasParent(index) && _arr[index] > _arr[Parent(index)])
        {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }
    public void Add(int value)
    {
        _arr.Add(value);
        _heapSize++;
        if (_heapSize == 1) return;
        HeapifyUp();
    }
    public int Delete()
    {
        var result = _arr[0];
        _arr[0] = _arr[_heapSize - 1];
        _heapSize--;
        HeapifyDown();
        _arr.RemoveAt(_arr.Count - 1);
        return result;
    }
    public int Peek()
    {
        if (_heapSize == 0) throw new InvalidOperationException("Heap is empty!");
        return _arr[0];
    }

}