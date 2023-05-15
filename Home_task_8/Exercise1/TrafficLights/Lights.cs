using System.Collections;

namespace Exercise1;

public class Lights : IEnumerator<Light>, ICloneable
{
    private Light[] _lightsArray;
    object IEnumerator.Current => Current;
    public int Count { get { return _lightsArray.Length; }}
    private int _index;

    public Light Current
    {
        get
        {
            try
            {
                return _lightsArray[_index];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public Lights(params Light[] lightsValues)
    {
        _index = 0;
        _lightsArray = (Light[])lightsValues.Clone();
    }
    public bool MoveNext()
    {
        if (_lightsArray == null) return false;
        if (_index + 1 == _lightsArray.GetLength(0))
        {
            _index = 0;
            return true;
        }
        ++_index;
        return true;
    }

    public void Reset()
    {
        _index = -1;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public object Clone()
    {
        return new Lights(_lightsArray);
    }
}