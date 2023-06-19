namespace Exercise1;


public class LuhnAlgorithmValidator : CardValidator
{
    public override bool Validate(Card card)
    {
        int sum = 0;
        bool alternate = false;
        for (int i = card.CardNumber.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(card.CardNumber[i].ToString());

            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit = (digit % 10) + 1;
                }
            }

            sum += digit;
            alternate = !alternate;
        }

        bool isValid = sum % 10 == 0;

        if (isValid && successor != null)
        {
            return successor.Validate(card);
        }
        return isValid;
    }
}