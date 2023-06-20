namespace Exercise1;

public static class QuickSort<T> where T : IComparable<T>
{
    public static void QuickSortAlgorithm(T[] arr, int left, int right, ChoosePivot pivotOption)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right, pivotOption);
            QuickSortAlgorithm(arr, left, pivotIndex - 1, pivotOption);
            QuickSortAlgorithm(arr, pivotIndex + 1, right, pivotOption);
        }
    }

    public static int Partition(T[] arr, int left, int right, ChoosePivot pivotOption)
    {
        int pivotIndex = ChoosePivotIndex(arr, left, right, pivotOption);
        T pivotValue = arr[pivotIndex];
        Swap(arr, pivotIndex, right);
        int storeIndex = left;
        for (int i = left; i < right; i++)
        {
            if (arr[i].CompareTo(pivotValue) < 0)
            {
                Swap(arr, i, storeIndex);
                storeIndex++;
            }
        }
        Swap(arr, storeIndex, right);
        return storeIndex;
    }

    public static int ChoosePivotIndex(T[] arr, int left, int right, ChoosePivot pivotOption)
    {
        if (pivotOption == ChoosePivot.First)
        {
            return left;
        }
        if (pivotOption == ChoosePivot.Random)
        {
            Random random = new Random();
            return random.Next(left, right + 1);
        }
        if (pivotOption == ChoosePivot.Median)
        {
            int mid = left + (right - left) / 2;
            if (arr[left].CompareTo(arr[mid]) <= 0 && arr[mid].CompareTo(arr[right]) <= 0)
                return mid;
            if (arr[mid].CompareTo(arr[left]) <= 0 && arr[left].CompareTo(arr[right]) <= 0)
                return left;
            return right;
        }
        return left;
    }
    
    private static void Swap(T[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}