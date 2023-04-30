using System.Collections;
using System.Text;

namespace Exercise1;

public class DiagonalEnumeratorGenerator : IEnumerable
{
    private int[,] _array;
    public DiagonalEnumeratorGenerator(int[,] array)
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
        int sizeI = _array.GetLength(0);
        int sizeJ = _array.GetLength(1);
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

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        int sizeI = _array.GetLength(0);
        int sizeJ = _array.GetLength(1);
        sb.AppendLine($"Start matrix size: {sizeI}x{sizeJ}");
        for (int i = 0; i < sizeI; i++)
        {
            for (int j = 0; j < sizeJ; j++)
            {
                sb.Append(_array[i, j] + "\t");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}