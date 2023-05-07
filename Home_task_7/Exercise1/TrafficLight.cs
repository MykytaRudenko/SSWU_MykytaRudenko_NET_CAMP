namespace Exercise1;

public delegate void LightHandler();
public class TrafficLight
{
    private string _name;
    private Lights _lights;
    
    public string Name { get { return _name; }}
    public Light CurrentLight { get{ return _lights.Current; }}
    
    public TrafficLight(string name, Lights lights)
    {
        _name = name;
        _lights = lights;
    }

    public void ChangeLight()
    {
        _lights.Next();
    }
}