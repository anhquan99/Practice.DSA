namespace Application;
public class MergeSort
{
    public static void Sort(int[] data, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            Sort(data, left, mid);
            Sort(data, mid + 1, right);

            Merge(data, left, mid, right);
        }
    }
    private static void Merge(int[] data, int left, int mid, int right)
    {
        int leftLength = mid - left + 1;
        int rightLength = right - mid;

        int[] L = new int[leftLength];
        int[] R = new int[rightLength];

        int i = 0, j = 0;
        for (i = 0; i < leftLength; i++)
        {
            L[i] = data[left + i];
        }
        for (j = 0; j < rightLength; j++)
        {
            R[j] = data[mid + 1 + j];
        }

        i = j = 0;

        int k = left;

        while (i < leftLength && j < rightLength)
        {
            if (L[i] <= R[j])
            {
                data[k] = L[i];
                i++;
            }
            else
            {
                data[k] = R[j];
                j++;
            }
            k++;
        }
        while (i < leftLength)
        {
            data[k] = L[i];
            i++;
            k++;
        }
        while (j < rightLength)
        {
            data[k] = R[j];
            j++;
            k++;
        }
    }
}