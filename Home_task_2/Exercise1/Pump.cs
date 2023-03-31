namespace Exercise1;

public class Pump
{
    private bool _isOn;
    public bool IsOn { get { return _isOn; } }
    private readonly double _power;
    public double Power { get { return _power; } }
    public Pump(double power)
    {
        _power = power;
        _isOn = false;
    }
    public void Turn()
    {
        if (_isOn)
        {
            _isOn = false;
            return;
        }
        _isOn = true;
    }

    public void Turn(bool isOn)
    {
        _isOn = isOn;
    }
}