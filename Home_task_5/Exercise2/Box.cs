using System.Text;

namespace Exercise2;

class Box : Product
{
    private List<Product> _products;

    private string _name;

    public Box(string name, params Product[] products)
        : base(products.Sum(p => p.Height), products.Max(p => p.Length), products.Max(p => p.Width))
    {
        _name = name;
        _products = new List<Product>(products);
    }
    public Box(string name, List<Product> products)
        : base(products.Sum(p => p.Height), products.Max(p => p.Length), products.Max(p => p.Width))
    {
        _name = name;
        _products = new List<Product>(products);
    }

    public static Box operator +(Box b, Product p)
    {
        var products = new List<Product>(b._products){p};
        return new Box("", products);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"\"{_name}\"" + "{\n");
        sb.Append($"height: {Height} length: {Length} width: {Width}\n");
        foreach (var product in _products)
        {
            sb.Append(product);
        }
        sb.Append("\n}  ");
        return sb.ToString();
    }
}