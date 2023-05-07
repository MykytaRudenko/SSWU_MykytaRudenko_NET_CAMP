using System.Text;

namespace Exercise1;
using System.Timers;

public class TrafficLightsContext
{
    private IStrategy _context;

    public TrafficLightsContext(IStrategy context)
    {
        _context = context;
    }

    public void StartTraffic()
    {
        _context.Start();
    }
}