using System.Timers;
using Timer = System.Timers.Timer;

namespace Exercise1;

public class ClassicTrafficLight : AbstractTrafficLight
{
    public ClassicTrafficLight(string name, uint greenDuration, uint redDuration) 
        : base(name, new Light("зелений", greenDuration),
            new Light("червоний", redDuration))
    {
        
    }
}