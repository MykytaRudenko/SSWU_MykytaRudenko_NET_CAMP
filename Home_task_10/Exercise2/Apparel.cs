namespace Exercise2;


public class Apparel : Item
{
    public double Weight { get; set; }

    public override void Accept(IShippingVisitor visitor)
    {
        visitor.Visit(this); 
    }
}
