namespace Exercise1;

public class Lights : ICloneable
{
    private Light[] _lightsArray;

    private int _index;
    public Light Current { get { return _lightsArray[_index]; } }
    public Lights(params Light[] lightsValues)
    {
        _lightsArray = (Light[])lightsValues.Clone();
    }
    public void Next()
    {
        if (_index + 1 == _lightsArray.GetLength(0))
        {
            _index = 0;
            return ;
        }
        ++_index;
    }

    public object Clone()
    {
        return new Lights(_lightsArray);
    }
}