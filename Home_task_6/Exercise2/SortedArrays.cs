using System.Collections;

namespace Exercise2;
// Злиття тут те, що треба)
public static class SortedArrays
{
    // для першого методу використав сортування злиттям,
    // так як не потрібно використовувати масив контейнер
    // для зберігання фінального масиву
    
    // також .Sort() зазвичай використовує Quick sort для сортування,
    // що у найгіршому випадку дає складність O(n^2), а сортування злиттям - O(n log n)
    public static IEnumerable<int> MergeSort(params int[][] arrays)
    {
        if (arrays.Length == 0)
        {
            yield break;
        }

        if (arrays.Length == 1)
        {
            foreach (int i in arrays[0])
            {
                yield return i;
            }
            yield break;
        }

        int middle = arrays.Length / 2;
        var leftArrays = new int[middle][];
        var rightArrays = new int[arrays.Length - middle][];

        Array.Copy(arrays, 0, leftArrays, 0, middle);
        Array.Copy(arrays, middle, rightArrays, 0, arrays.Length - middle);

        var left = MergeSort(leftArrays);
        var right = MergeSort(rightArrays);

        using (var leftEnumerator = left.GetEnumerator())
        using (var rightEnumerator = right.GetEnumerator())
        {
            bool leftSuccess = leftEnumerator.MoveNext();
            bool rightSuccess = rightEnumerator.MoveNext();

            while (leftSuccess && rightSuccess)
            {
                if (leftEnumerator.Current < rightEnumerator.Current)
                {
                    yield return leftEnumerator.Current;
                    leftSuccess = leftEnumerator.MoveNext();
                }
                else
                {
                    yield return rightEnumerator.Current;
                    rightSuccess = rightEnumerator.MoveNext();
                }
            }

            while (leftSuccess)
            {
                yield return leftEnumerator.Current;
                leftSuccess = leftEnumerator.MoveNext();
            }

            while (rightSuccess)
            {
                yield return rightEnumerator.Current;
                rightSuccess = rightEnumerator.MoveNext();
            }
        }
    }
    
    // інший варіант просто з .Sort()
    public static IEnumerable<int> MergeSortedArrays(params int[][] arrays)
    {
        List<int> result = new List<int>();
        foreach (int[] array in arrays)
        {
            if (array == null) continue;
            result.AddRange(array);
        }
        result.Sort();
        foreach (int item in result)
        {
            yield return item;
        }
    }
}
