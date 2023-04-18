namespace Exercise2;

class Box
{
    private List<Product> _products;

    private string _name;
    private double _height;
    private double _length;
    private double _width;

    public Box(string name, params Product[] products)
    {
        _name = name;
        _products = new List<Product>(products);
        CalculateDimensions();
    }
    public Box(string name, List<Product> products)
    {
        _name = name;
        _products = new List<Product>(products);
        CalculateDimensions();
    }
    private void CalculateDimensions()
    {
        _width = _products.Max(p => p.Width);
        _height = _products.Sum(p => p.Height);
        _length = _products.Max(p => p.Length);
    }

    public static Box operator +(Box b, Product p)
    {
        var products = new List<Product>(b._products){p};
        return new Box("", products);
    }

    public override string ToString()
    {
        return $"{_products.Count} products, {_height}x{_length}x{_width}";
    }
}