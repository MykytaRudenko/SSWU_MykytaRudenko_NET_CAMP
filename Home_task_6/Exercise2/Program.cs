
using Exercise2;

int[] arr1 = { 11, 33, 55, 70 };
int[] arr2 = { 22, 44, 66, 88 };
int[] arr3 = { 0, 22, 77 };
int[] arr4 = { 3, 33 };

IEnumerable<int> sortedArr = SortedArrays.MergeSort(arr1, arr2, arr3, arr4);

foreach (var item in sortedArr)
{
    Console.Write(item + ", ");
}
Console.WriteLine("\n" + new string('-', 50) + "\n");

sortedArr = SortedArrays.MergeSortedArrays(arr1, arr2, arr3, arr4);
foreach (var item in sortedArr)
{
    Console.Write(item + ", ");
}