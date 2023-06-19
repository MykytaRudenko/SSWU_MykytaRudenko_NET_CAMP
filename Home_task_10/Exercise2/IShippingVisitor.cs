namespace Exercise2;


public interface IShippingVisitor
{
    void Visit(Product product);
    void Visit(Electronics electronics);
    void Visit(Apparel apparel);
}