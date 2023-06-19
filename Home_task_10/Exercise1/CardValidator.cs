namespace Exercise1;


public abstract class CardValidator
{
    protected CardValidator successor;

    public void SetSuccessor(CardValidator successor)
    {
        this.successor = successor;
    }

    public abstract bool Validate(Card card);
}