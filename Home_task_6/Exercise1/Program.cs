using System.Collections;
using Exercise1;

int[,] array =
{
    {1, 2, 3, 4, 5}, 
    {6, 7, 8, 9, 10}, 
    {11, 12, 13, 14, 15}, 
    {16, 17, 18, 19, 20}, 
    {21, 22, 23, 24, 25}
};
IEnumerator enumerator = new DiagonalSnakeEnumerator(array).GetEnumerator();
while (enumerator.MoveNext())
{
    Console.Write(enumerator.Current + ", ");
}

Console.WriteLine();
Console.WriteLine(new string('-', 50));
int[,] array4x4 =
{
    {1, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12},
    {13, 14, 15, 16}
};
enumerator = new DiagonalSnakeEnumerator(array4x4).GetEnumerator();
while (enumerator.MoveNext())
{
    Console.Write(enumerator.Current + ", ");
}