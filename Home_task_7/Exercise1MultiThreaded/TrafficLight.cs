using System.Timers;
using Timer = System.Timers.Timer;

namespace Exercise1;

public class TrafficLight
{
    private string _name;
    private Lights _lights;
    private Timer _timer;
    private static object _lockObj = new object();
    
    public string Name { get { return _name; }}
    public Light CurrentLight { get{ return _lights.Current; }}

    public TrafficLight(string name, Lights lights)
    {
        _name = (string)name.Clone();
        _lights = (Lights)lights.Clone();
    }

    public void Start()
    {
        _timer = new Timer(CurrentLight.Duration);
        _timer.AutoReset = true;
        _timer.Elapsed += OnElapsed;
        _timer.Start();
    }

    private void OnElapsed(Object source, ElapsedEventArgs e)
    {
        lock (_lockObj)
        {
            _timer.Stop();
            _lights.Next();
            _timer.Interval = CurrentLight.Duration;
            _timer.Start();
        }
    }

    public void Stop()
    {
        _timer.Stop();
        _timer.Dispose();
    }
}