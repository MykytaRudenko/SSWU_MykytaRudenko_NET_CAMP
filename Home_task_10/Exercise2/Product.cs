namespace Exercise2;

public class Product : Item
{
    public double Weight { get; set; }
    public bool IsPerishable { get; set; }

    public override void Accept(IShippingVisitor visitor)
    {
        visitor.Visit(this);
    }
}