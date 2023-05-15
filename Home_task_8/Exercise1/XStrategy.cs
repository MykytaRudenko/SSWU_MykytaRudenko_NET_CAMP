using System.Text;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Exercise1;

public class XStrategy : IStrategy
{
    private Timer _timer;
    private uint _statusInterval;
    private List<AbstractTrafficLight>[] _trafficLightLines;

    private uint _greenDuration;
    private uint _redDuration;

    public XStrategy(uint statusInterval, uint greenDuration, uint redDuration)
    {
        _statusInterval = statusInterval;
        _greenDuration = greenDuration;
        _redDuration = redDuration;

        _trafficLightLines = new List<AbstractTrafficLight>[2];
        
        _trafficLightLines[0] = new List<AbstractTrafficLight>()
        {
            new ClassicTrafficLight("Північ-південь", _greenDuration, _redDuration),
            new ClassicTrafficLight("Південь-північ", _greenDuration, _redDuration),
        };
        _trafficLightLines[1] = new List<AbstractTrafficLight>()
        {
            new ClassicTrafficLight("Схід-захід", _greenDuration, _redDuration),
            new ClassicTrafficLight("Захід-схід", _greenDuration, _redDuration),
        };
    }

    public void Start()
    {
        
        foreach (var trafficLight in _trafficLightLines[0]) 
        {
            trafficLight.Start();
        }

        foreach (var trafficLight in _trafficLightLines[1])
        {
            if (trafficLight is TurnTrafficLight)
            {
                TurnTrafficLight turnTrafficLight = (TurnTrafficLight)trafficLight;
                turnTrafficLight.Start("червоний", false);
            }
            else
            {
                trafficLight.Start("червоний");
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
        return new XStrategy(_statusInterval, _greenDuration, _redDuration);
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"t = {DateTime.Now:mm:ss}");
        sb.Append("Світлофор\t");
        foreach (var line in _trafficLightLines)
        {
            foreach (var trafficLight in line)
            {
                sb.Append($"{trafficLight.Name, -20}|");
            }
        }

        sb.AppendLine("\n" + new string('-', 100));
        sb.Append("Колір\t\t");
        foreach (var line in _trafficLightLines)
        {
            foreach (var trafficLight in line)
            {
                sb.Append($"{trafficLight.Lights.Current.Color, -20}|");
            }
        }
        sb.AppendLine("\n" + new string('-', 100));
        return sb.ToString();
    }
}