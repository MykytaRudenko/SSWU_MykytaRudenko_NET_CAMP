namespace Exercise1;

public class Context
{
    private IStrategy _context;

    public Context(IStrategy context)
    {
        _context = (IStrategy)context.Clone();
    }

    public void AddContext(IStrategy context)
    {
        _context = (IStrategy)context.Clone();
    }

    public void StartTraffic()
    {
        _context.Start();
    }
}