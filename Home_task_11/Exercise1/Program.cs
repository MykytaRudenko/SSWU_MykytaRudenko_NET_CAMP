using Exercise1;

int[] arr1 = { 7, 2, 1, 6, 8, 5, 3, 4 };
Console.WriteLine("Масив до сортування: " + string.Join(", ", arr1));
QuickSort<int>.QuickSortAlgorithm(arr1, 0, arr1.Length - 1, ChoosePivot.First);
Console.WriteLine("Масив після сортування з першим елементом як опорним: " + string.Join(", ", arr1));

string[] arr2 = { "orange", "apple", "banana", "grape", "kiwi" };
Console.WriteLine("Масив до сортування: " + string.Join(", ", arr2));
QuickSort<string>.QuickSortAlgorithm(arr2, 0, arr2.Length - 1, ChoosePivot.Random);
Console.WriteLine("Масив після сортування з довільним елементом як опорним: " + string.Join(", ", arr2));