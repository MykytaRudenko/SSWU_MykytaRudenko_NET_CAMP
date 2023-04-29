using System.Collections;

namespace Exercise1;

public class DiagonalSnakeEnumerator : IEnumerable
{
    private int[,] _array;
    public DiagonalSnakeEnumerator(int[,] array)
    {
        _array = array;
    }
    public IEnumerator GetEnumerator()
    {
        Directions verticalDirection = new Directions(1, -1);
        Directions horizontalDirection = new Directions(-1, 1);
        int counter = 0;
        int i = 0;
        int j = 0;
        int sizeJ = _array.GetLength(0);
        int sizeI = _array.GetLength(1);
        while (counter < sizeI * sizeJ)
        {
            yield return _array[i, j];
            if((j == 0 || j == sizeJ - 1) && i != sizeI - 1)
            {
                ++i;
                ++counter;
                yield return _array[i, j];
                verticalDirection.Next();
                horizontalDirection.Next();
            }
            else if (i == 0 || i == sizeI - 1)
            {
                ++j;
                ++counter;
                yield return _array[i, j];
                verticalDirection.Next();
                horizontalDirection.Next();
            }
            i += verticalDirection.Current;
            j += horizontalDirection.Current;
            ++counter;
        }
    }
    private bool CheckChangeDirection(int row, int col)
    {
        bool isBound = (col == _array.GetLength(1) - 1 && row == 0) ||
                       (col == _array.GetLength(1) - 1 && row == _array.GetLength(0) - 1) ||
                       (row == _array.GetLength(0) - 1 && col == 0);
        return isBound;
    }
}