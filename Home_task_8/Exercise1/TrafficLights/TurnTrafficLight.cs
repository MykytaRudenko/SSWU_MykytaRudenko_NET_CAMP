using System.Timers;
using Timer = System.Timers.Timer;

namespace Exercise1;

public class TurnTrafficLight : AbstractTrafficLight
{
    private TurnLight _turnLight;
    private Timer _turnTimer;
    
    public TurnLight TurnLight{ get { return _turnLight; }}

    public TurnTrafficLight(string name, uint redDuration, uint greenDuration, uint turnDuration) 
        : base(name, new Light("зелений", greenDuration),
            new Light("червоний", redDuration))
    {
        _turnLight = new TurnLight(true, turnDuration);
    }
    
    public override void Start()
    {
        base.Start();
        _turnTimer = new Timer(_turnLight.TurnDuration);
        _turnTimer.Elapsed += OnTurnEvent;
        _turnTimer.AutoReset = true;
        _turnTimer.Start();
    }

    public void Start(string startColor, bool isTurnLightOn)
    {
        _turnLight.IsTurnLightOn = isTurnLightOn;
        base.Start(startColor);
    }

    protected override void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        _turnTimer.Stop();
        base.OnTimedEvent(source, e);
    }

    protected override void OnYellowEvent(Object source, ElapsedEventArgs e)
    {
        _turnTimer.Start();
        base.OnYellowEvent(source, e);
    }

    private void OnTurnEvent(Object source, ElapsedEventArgs e)
    {
        _turnLight.Turn();
    }

    public void Stop()
    {
        base.Stop();
        _turnTimer.Stop();
        _turnTimer.Dispose();
    }
}