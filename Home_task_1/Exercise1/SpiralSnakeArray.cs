using System.Text;

namespace Exercise1;

public class SpiralSnakeArray
{
    private int _sizeX;
    private int _sizeY;
    private int[,] _array;

    public SpiralSnakeArray(int sizeY = 3, int sizeX = 4)
    {
        _sizeX = sizeX;
        _sizeY = sizeY;
        _array = new int[sizeY,sizeX];
        CreateSpiral();
    }
    private void CreateSpiral()
    {
        int value = 1;
        int counter = 0;
        int col = 0;
        int row = 0;
        Directions verticalDirection = new Directions();
        Directions horizontalDirection = new Directions();
        verticalDirection.Next();

        while (counter < _sizeX * _sizeY)
        {
            _array[row, col] = value++;
            if(CheckChangeDirection(row, col, row + verticalDirection.Current, col + horizontalDirection.Current))
            {//Трішки перемудровано. Я на занятті поясню.
                verticalDirection.Next();
                horizontalDirection.Next();
            }
            row += verticalDirection.Current;
            col += horizontalDirection.Current;
            counter++;
        }
    }

    private bool CheckChangeDirection(int row, int col, int nextRow, int nextCol)
    {
        bool isBound = (col == _array.GetLength(1) - 1 && row == 0) ||
                       (col == _array.GetLength(1) - 1 && row == _array.GetLength(0) - 1) ||
                       (row == _array.GetLength(0) - 1 && col == 0);
        if (isBound || _array[nextRow, nextCol] != 0) return true;
        return false;
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < _sizeY; i++)
        {
            sb.Append("\n");
            for (int j = 0; j < _sizeX; j++)
            {
                sb.Append(_array[i,j] + "\t");
            }
        }
        return sb.ToString();
    }
}
