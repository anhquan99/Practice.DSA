namespace Application;
// Ref: https://www.geeksforgeeks.org/introduction-to-heap-data-structure-and-algorithm-tutorials/
public class MaxHeap
{
    int[] _arr;
    int _maxSize;
    int _heapSize;
    public MaxHeap(int _maxSize)
    {
        this._maxSize = _maxSize;
        _arr = new int[_maxSize];
        _heapSize = 0;
    }
    int Parent(int i) => (i - 1) / 2;
    int LeftChild(int i) => (2 * i + 1);
    int RightChild(int i) => (2 * i + 2);
    public int GetMax() => _arr[0];
    public int CurrentSize() => _heapSize;
    // given index is the root
    void MaxHeapify(int i)
    {
        int left = LeftChild(i), right = RightChild(i), largest = i;
        if (left < _heapSize && _arr[left] > _arr[i])
        {
            largest = left;
        }
        if (right < _heapSize && _arr[right] > _arr[largest])
        {
            largest = right;
        }
        if (largest != i)
        {
            var temp = _arr[i];
            _arr[i] = _arr[largest];
            _arr[largest] = temp;
            MaxHeapify(largest);
        }
    }
    // Removes the root which is max
    int RemoveMax()
    {
        if (_heapSize <= 0)
        {
            throw new IndexOutOfRangeException("Heap is empty");
        }
        if (_heapSize == 1)
        {
            _heapSize--;
            return _arr[0];
        }
        var root = _arr[0];
        _arr[0] = _arr[_heapSize - 1];
        _heapSize--;
        MaxHeapify(0);
        return root;
    }
    void IncreaseKey(int i, int newVal)
    {
        _arr[i] = newVal;
        while (i != 0 && _arr[Parent(i)] < _arr[i])
        {
            var temp = _arr[i];
            _arr[i] = _arr[Parent(i)];
            _arr[Parent(i)] = temp;
            i = Parent(i);
        }
    }

    public void DeleteKey(int i)
    {
        IncreaseKey(i, int.MaxValue);
        RemoveMax();
    }
    public void InsertKey(int x)
    {
        if (_heapSize == _maxSize)
        {
            throw new IndexOutOfRangeException("Heap is full");
        }
        _heapSize++;
        var i = _heapSize - 1;
        _arr[i] = x;
        while (i != 0 && _arr[Parent(i)] < _arr[i])
        {
            var tmp = _arr[i];
            _arr[i] = _arr[Parent(i)];
            _arr[Parent(i)] = tmp;
            i = Parent(i);
        }
    }
}