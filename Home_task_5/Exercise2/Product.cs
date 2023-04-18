using System.Text;

namespace Exercise2;

public class Product
{
    private double _height;
    private double _length;
    private double _width;
    
    public double Height{ get { return _height; } }
    public double Length{ get { return _length; } }
    public double Width{ get { return _width; } }
    
    public Product(double height, double length, double width)
    {
        _height = height;
        _length = length;
        _width = width;
    }

    public override string ToString()
    {
        return "";
    }
}