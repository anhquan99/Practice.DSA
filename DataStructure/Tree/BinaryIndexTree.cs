namespace Application;
public class BIT
{
    private int[] bit;

    public BIT(int size)
    {
        bit = new int[size + 1]; // 1-based indexing
    }

    public void Update(int index, int value)
    {
        index++; // 1-based indexing
        while (index < bit.Length)
        {
            bit[index] += value;
            index += (index & -index); // Move to next relevant index
        }
    }

    public int Query(int index)
    {
        int sum = 0;
        index++; // 1-based indexing
        while (index > 0)
        {
            sum += bit[index];
            index -= (index & -index); // Move to parent index
        }
        return sum;
    }
}