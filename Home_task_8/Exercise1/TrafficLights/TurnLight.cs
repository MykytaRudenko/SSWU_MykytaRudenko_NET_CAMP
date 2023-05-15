namespace Exercise1;

public class TurnLight
{
    private bool _isTurnLightOn;
    private uint _turnDuration;
    
    public bool IsTurnLightOn { get { return _isTurnLightOn; } set { _isTurnLightOn = value; } }
    public uint TurnDuration { get { return _turnDuration; }}

    public TurnLight(bool isTurnLightOn, uint turnDuration)
    {
        _isTurnLightOn = isTurnLightOn;
        _turnDuration = turnDuration;
    }

    public void Turn()
    {
        if (_isTurnLightOn)
        {
            _isTurnLightOn = false;
            return;
        }
        _isTurnLightOn = true;
    }
}