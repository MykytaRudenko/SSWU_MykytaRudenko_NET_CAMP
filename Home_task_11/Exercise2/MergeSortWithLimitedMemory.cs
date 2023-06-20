namespace Exercise2;

public static class MergeSortWithLimitedMemory
{
    public static void MergeSort(string filePath)
    {
        const int GroupSize = 50;
        
        int[] numbers = File.ReadAllLines(filePath)
            .Select(int.Parse)
            .ToArray();
        
        for (int i = 0; i < numbers.Length; i += GroupSize)
        {
            int endIndex = Math.Min(i + GroupSize - 1, numbers.Length - 1);
            Array.Sort(numbers, i, endIndex - i + 1);
        }
        
        int[] merged = MergeGroups(numbers, GroupSize);
        
        File.WriteAllLines(filePath, merged.Select(num => num.ToString()));
    }

    private static int[] MergeGroups(int[] numbers, int groupSize)
    {
        int numGroups = (int)Math.Ceiling((double)numbers.Length / groupSize);
        int[] merged = new int[numbers.Length];
        int[] indices = new int[numGroups];

        for (int i = 0; i < merged.Length; i++)
        {
            int minIndex = -1;
            int minValue = int.MaxValue;

            for (int j = 0; j < numGroups; j++)
            {
                int index = indices[j];

                if (index < (j + 1) * groupSize && index < numbers.Length && numbers[index] < minValue)
                {
                    minIndex = j;
                    minValue = numbers[index];
                }
            }

            merged[i] = minValue;
            indices[minIndex]++;
        }
        return merged;
    }
}