namespace Exercise2;

public class Electronics : Item
{
    public double Weight { get; set; }
    public double Size { get; set; }
    public double OversizeFeePercentage { get; set; }

    public override void Accept(IShippingVisitor visitor)
    {
        visitor.Visit(this);
    }
}