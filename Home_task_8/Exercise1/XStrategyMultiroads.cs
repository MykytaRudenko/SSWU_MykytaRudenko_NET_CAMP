using System.Text;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Exercise1;

public class XStrategyMultiroads : IStrategy
{
    private System.Timers.Timer _timer;
    private uint _statusInterval;
    private uint _numberOfRoadsInLine;
    private List<AbstractTrafficLight>[] _trafficLightLines;

    private uint _greenDuration;
    private uint _redDuration;
    private uint _turnDuration;

    public XStrategyMultiroads(uint numberOfRoadsInLine, uint statusInterval, uint greenDuration, uint redDuration, uint turnDuration)
    {
        _statusInterval = statusInterval;
        _greenDuration = greenDuration;
        _redDuration = redDuration;
        _turnDuration = turnDuration;
        _numberOfRoadsInLine = numberOfRoadsInLine;
        
        _trafficLightLines = new List<AbstractTrafficLight>[2];

        _trafficLightLines[0] = new List<AbstractTrafficLight>();
        _trafficLightLines[1] = new List<AbstractTrafficLight>();
        
        // дороги, що вертикальні по сторонам світу
        for (int i = 0; i < _numberOfRoadsInLine - 1; i++)
        {
            _trafficLightLines[0].Add(new ClassicTrafficLight($"Північ-південь {i + 1}", _greenDuration, _redDuration));
        }
        // найправіша дорога за рухом машин має світлофор з поворотом,
        // а інші дороги мають звичайні світлофорі, які не дозволяють повертати на перехресті
        _trafficLightLines[0].Add(new TurnTrafficLight($"Північ-південь {_numberOfRoadsInLine}", _greenDuration, _redDuration, _turnDuration));
        
        for (int i = 0; i < _numberOfRoadsInLine - 1; i++)
        {
            _trafficLightLines[0].Add(new ClassicTrafficLight($"Південь-північ {i + 1}", _greenDuration, _redDuration));
        }
        _trafficLightLines[0].Add(new TurnTrafficLight($"Південь-північ {_numberOfRoadsInLine}", _greenDuration, _redDuration, _turnDuration));
        
        // перпендикулярні дороги першим
        for (int i = 0; i < _numberOfRoadsInLine - 1; i++)
        {
            _trafficLightLines[1].Add(new ClassicTrafficLight($"Схід-захід {i + 1}", _greenDuration, _redDuration));
        }
        _trafficLightLines[1].Add(new TurnTrafficLight($"Схід-захід {_numberOfRoadsInLine}", _greenDuration, _redDuration, _turnDuration));
        
        for (int i = 0; i < _numberOfRoadsInLine - 1; i++)
        {
            _trafficLightLines[1].Add(new ClassicTrafficLight($"Захід-схід {i + 1}", _greenDuration, _redDuration));
        }
        _trafficLightLines[1].Add(new TurnTrafficLight($"Захід-схід {_numberOfRoadsInLine}", _greenDuration, _redDuration, _turnDuration));
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
        Console.WriteLine(this.ToString());
    }

    public object Clone()
    {
        return new XStrategyMultiroads(_numberOfRoadsInLine, _statusInterval, _greenDuration, _redDuration, _turnDuration);
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

        sb.AppendLine(new string('-', 180));
        sb.Append("Колір\t\t");
        foreach (var line in _trafficLightLines)
        {
            foreach (var trafficLight in line)
            {
                sb.Append($"{trafficLight.Lights.Current.Color, -10}");
                if (trafficLight is TurnTrafficLight)
                {
                    TurnTrafficLight turnTrafficLight = (TurnTrafficLight)trafficLight;
                    if (turnTrafficLight.TurnLight.IsTurnLightOn)
                    {
                        sb.Append($"{"поворотний", 10}|");
                        continue;
                    }
                }
                sb.Append(new string(' ', 10));
                sb.Append("|");
            }
        }
        sb.AppendLine(new string('-', 180));
        return sb.ToString();
    }
}