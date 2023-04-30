using System.Collections;
using Exercise1;

int[,] array5x5 =
{
    {1, 2, 3, 4, 5}, 
    {6, 7, 8, 9, 10}, 
    {11, 12, 13, 14, 15}, 
    {16, 17, 18, 19, 20}, 
    {21, 22, 23, 24, 25}
};
var generator = new DiagonalEnumeratorGenerator(array5x5);
IEnumerator enumerator = generator.GetEnumerator();
Console.WriteLine(generator.ToString());
while (enumerator.MoveNext())
{
    Console.Write(enumerator.Current + ", ");
}

Console.WriteLine();
Console.WriteLine(new string('-', 50));
int[,] array3x4 =
{
    {1, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12}
};
generator = new DiagonalEnumeratorGenerator(array3x4);
enumerator = generator.GetEnumerator();
Console.WriteLine(generator.ToString());
while (enumerator.MoveNext())
{
    Console.Write(enumerator.Current + ", ");
}