using Exercise2;


List<Item> items = new List<Item>
{
    new Product { Weight = 2.5, IsPerishable = true },
    new Electronics { Weight = 5.0, Size = 1.2, OversizeFeePercentage = 0.1 },
    new Apparel { Weight = 1.0 },
};

ShippingCostVisitor visitor = new ShippingCostVisitor();
foreach (var item in items)
{
    item.Accept(visitor);
}

Console.WriteLine($"Total shipping cost: {visitor.TotalShippingCost}");