namespace Exercise1;

public class AmericanExpressValidator : CardValidator
{
    public override bool Validate(Card card)
    {
        if (card.CardNumber.Length == 15 &&
            (card.CardNumber[0] == 3 && (card.CardNumber[1] == 4 || card.CardNumber[1] == 7)))
        {
            card.CardType = CardType.AmericanExpress;
            return true;
        }
        if (successor != null)
        {
            return successor.Validate(card);
        }
        return false;
    }
}