namespace Exercise1;

public class Context
{
    private List<IStrategy> _strategies;
    public Context(params IStrategy[] strategy)
    {
        _strategies = new List<IStrategy>(strategy);
    }

    public void AddStrategy(IStrategy strategy)
    {
        _strategies.Add((IStrategy)strategy.Clone());
    }

    public void StartTraffic()
    {
        foreach (var strategy in _strategies)
        {
            strategy.Start();
        }
    }
}