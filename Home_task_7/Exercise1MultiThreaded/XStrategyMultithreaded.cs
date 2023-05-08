using System.Text;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Exercise1;

public class XStrategyMultithreaded : IStrategy
{
    private Timer _timer;
    private uint _statusInterval;
    private List<TrafficLight>[] _trafficLightLines;

    public XStrategyMultithreaded(uint statusInterval, uint redAndGreenDuration)
    {
        _statusInterval = statusInterval;
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
        foreach (var line in _trafficLightLines)
        {
            foreach (var trafficLight in line)
            {
                trafficLight.Start();
            }
        }

        _timer = new Timer(_statusInterval);
        _timer.AutoReset = true;
        _timer.Elapsed += OnElapsed;
        _timer.Start();
        Console.ReadLine();
        _timer.Stop();
        
        foreach (var line in _trafficLightLines)
        {
            foreach (var trafficLight in line)
            {
                trafficLight.Stop();
            }
        }
        _timer.Dispose();
    }

    private void OnElapsed(Object source, ElapsedEventArgs e)
    {
        Console.WriteLine(ToString());
    }

    public object Clone()
    {
        return new XStrategyMultithreaded(_statusInterval, _trafficLightLines[0][0].CurrentLight.Duration);
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