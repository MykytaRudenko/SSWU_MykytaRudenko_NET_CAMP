namespace Exercise1;

public class Light
{
    private string _color;
    private uint _duration;
    
    // properties
    public string Color { get { return _color; }}
    public uint Duration { get { return _duration; }}
    
    public Light(string color, uint duration)
    {
        _color = color;
        _duration = duration;
    }
}