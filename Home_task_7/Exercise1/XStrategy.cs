using System.Text;
using System.Timers;
using Timer = System.Timers.Timer;
namespace Exercise1;

public class XStrategy : IStrategy
{
    private Timer _timer;
    private List<TrafficLight>[] _trafficLightLines;
    
    private static object lockObj = new object();

    public XStrategy(uint redAndGreenDuration)
    {
        _trafficLightLines = new List<TrafficLight>[2];
        Lights firstLineLights = new Lights(new Light("червоний", redAndGreenDuration), new Light("жовтий", 1000), new Light("зелений", redAndGreenDuration), new Light("жовтий", 1000));
        _trafficLightLines[0] = new List<TrafficLight>()
        {
            new TrafficLight("Північ-південь", firstLineLights),
            new TrafficLight("Південь-північ", firstLineLights)
        };
        Lights secondLineLights= new Lights(new Light("зелений", redAndGreenDuration), new Light("жовтий", 1000), new Light("червоний", redAndGreenDuration), new Light("жовтий", 1000));
        _trafficLightLines[1] = new List<TrafficLight>()
        {
            new TrafficLight("Схід-захід", secondLineLights),
            new TrafficLight("Захід-схід", secondLineLights)
        };
    }

    public void Start()
    {
        _timer = new Timer();
        lock (lockObj)
        {
            _timer.Interval = _trafficLightLines[0][0].CurrentLight.Duration;
        }
        _timer.Elapsed += OnElapsed;
        _timer.AutoReset = true;
        _timer.Start();
        Console.ReadLine();
        _timer.Stop();
        _timer.Dispose();
    }

    private void OnElapsed(Object source, ElapsedEventArgs e)
    {
        // блокування потоку об'єктом для білшої безпеки
        lock (lockObj)
        {
            Console.WriteLine(ToString());
            ChangeAllLights();
            _timer.Stop();
            _timer.Interval = (int)_trafficLightLines[0][0].CurrentLight.Duration;
            _timer.Start();
        }
    }

    private void ChangeAllLights()
    {
        foreach (var line in _trafficLightLines)
        {
            foreach (var trafficLight in line)
            {
             trafficLight.ChangeLight();   
            }
        }
    }

    public object Clone()
    {
        return new XStrategy(_trafficLightLines[0][0].CurrentLight.Duration);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"t = {_trafficLightLines[0][0].CurrentLight.Duration} мс");
        sb.Append("Світлофор\t");
        foreach (var line in _trafficLightLines)
        {
            foreach (var trafficLight in line)
            {
                sb.Append(trafficLight.Name + "\t");
            }
        }
        sb.Append("\nКолір\t");
        foreach (var line in _trafficLightLines)
        {
            foreach (var trafficLight in line)
            {
                sb.Append(trafficLight.CurrentLight.Color + "\t");
            }
        }
        return sb.ToString();
    }
}