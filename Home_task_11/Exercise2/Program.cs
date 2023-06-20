using Exercise2;

string path = "../../../testFile.txt";

GenerateRandomNumbers(path, 100, 1, 1000);

MergeSortWithLimitedMemory.MergeSort(path);
Console.WriteLine("Числа відсортовані!!!");


void GenerateRandomNumbers(string filename, int count, int minValue, int maxValue)
{
    Random random = new Random();

    using (StreamWriter writer = new StreamWriter(filename))
    {
        for (int i = 0; i < count; i++)
        {
            int number = random.Next(minValue, maxValue + 1);
            writer.WriteLine(number);
        }
    }
}