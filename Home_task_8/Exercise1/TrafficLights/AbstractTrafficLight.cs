using System.Timers;
using Timer = System.Timers.Timer;

namespace Exercise1;

public class AbstractTrafficLight : ITrafficLight
{
    private string _name;
    private Lights _lights;

    private const uint YELLOW_DURATION = 1000;
    
    private Timer _timer;
    protected static object _lockObj = new object();

    public string Name { get { return _name; }}
    public Lights Lights { get { return _lights; }}
    protected Timer Timer { get { return _timer; } }

    public AbstractTrafficLight(string name, params Light[] lights)
    {
        _name = (string)name.Clone();
        _lights = new Lights(lights);
    }
    
    public virtual void Start()
    {
        _timer = new Timer(Lights.Current.Duration);
        _timer.AutoReset = true;
        _timer.Elapsed += OnTimedEvent;
        _timer.Start();
    }
    protected virtual void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        lock (_lockObj)
        {
            _timer.Stop();
            Lights.MoveNext();
            _timer.Elapsed -= OnTimedEvent;
            _timer.Elapsed += OnYellowEvent;
            _timer.Interval = YELLOW_DURATION;
            _timer.Start();
        }
    }
    
    // жовтий кольор не виводжу, а просто роблю затримку, коли змінюється колір,
    // додає можливість створювати світофори не тільки з 2 кольорами
    protected virtual void OnYellowEvent(Object source, ElapsedEventArgs e)
    {
        lock (_lockObj)
        {
            _timer.Stop();
            _timer.Elapsed += OnTimedEvent;
            _timer.Elapsed -= OnYellowEvent;
            _timer.Interval = Lights.Current.Duration;
            _timer.Start();
        }
    }
    public void Start(string startColor)
    {
        bool isEquals = false;
        for (int i = 0; i < Lights.Count; i++)
        {
            if (startColor.Equals(Lights.Current.Color))
            {
                isEquals = true;
                break;
            }
            Lights.MoveNext();
        }
        if(!isEquals) Console.WriteLine("Color not found!");
        Start();
    }
    public virtual void Stop()
    {
        _timer.Stop();
        _timer.Dispose();
    }
}