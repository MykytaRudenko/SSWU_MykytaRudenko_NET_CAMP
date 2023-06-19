namespace Exercise1;

public class MasterCardValidator : CardValidator
{
    public override bool Validate(Card card)
    {
        if (card.CardNumber.Length == 16 && (card.CardNumber[0] == 5 && (card.CardNumber[1] >= 1 && card.CardNumber[1] <= 5)))
        {
            card.CardType = CardType.MasterCard;
            return true;
        }
        if (successor != null)
        {
            return successor.Validate(card);
        }
        return false;
    }
}