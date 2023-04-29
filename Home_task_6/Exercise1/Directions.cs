namespace Exercise1;

public class Directions
{
    private int[] _directionsArray;
    public int[] Array { get; }

    private int _index;
    public int Current { get { return _directionsArray[_index]; } }
    public Directions(params int[] directionValues)
    {
        _directionsArray = directionValues;
    }
    public void Next()
    {
        if (_index + 1 == _directionsArray.GetLength(0))
        {
            _index = 0;
            return ;
        }
        ++_index;
    }
}