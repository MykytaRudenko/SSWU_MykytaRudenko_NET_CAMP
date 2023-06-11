namespace Exercise2;

public class ShippingCostVisitor : IShippingVisitor
{
    public double TotalShippingCost { get; private set; }

    public void Visit(Product product)
    {
        double shippingCost = product.Weight * (product.IsPerishable ? 1.2 : 1.0);
        TotalShippingCost += shippingCost;
    }

    public void Visit(Electronics electronics)
    {
        double shippingCost = electronics.Weight + electronics.Size * electronics.OversizeFeePercentage;
        TotalShippingCost += shippingCost;
    }

    public void Visit(Apparel apparel)
    {
        double shippingCost = apparel.Weight * 0.8;
        TotalShippingCost += shippingCost;
    }
}