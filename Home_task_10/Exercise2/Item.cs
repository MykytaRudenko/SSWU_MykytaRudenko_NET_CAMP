namespace Exercise2;


public abstract class Item
{
    public abstract void Accept(IShippingVisitor visitor);
}