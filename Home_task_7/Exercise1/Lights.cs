namespace Exercise1;

public class Lights
{
    private Light[] _lightsArray;

    private int _index;
    public Light Current { get { return _lightsArray[_index]; } }
    public Lights(params Light[] lightsValues)
    {
        _index = 0;
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
}