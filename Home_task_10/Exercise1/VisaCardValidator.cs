namespace Exercise1;


public class VisaCardValidator : CardValidator
{
    public override bool Validate(Card card)
    {
        if ((card.CardNumber.Length == 16 || card.CardNumber.Length == 13) && card.CardNumber[0] == 4)
        {
            card.CardType = CardType.Visa;
            return true;
        }
        if (successor != null)
        {
            return successor.Validate(card);
        }
        return false;
    }
}