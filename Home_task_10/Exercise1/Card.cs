using System.Text;

namespace Exercise1;

public class Card
{
    private CardType _cardType;
    private int[] _cardNumber;
    public CardType CardType { get { return _cardType; } set { _cardType = value; }}

    public int[] CardNumber
    {
        get
        {
            return _cardNumber;
        }
        private set
        {

            if (value.Length > 16 || value.Length < 13) throw new Exception("Credit card number can`t contain " + value.Length + " symbols.");
            _cardNumber = value;
        }
    }

    public Card(int[] cardNumber, CardType cardType = CardType.Unknown)
    {
        _cardType = cardType;
        CardNumber = cardNumber;
    }
    public Card(string cardNumber, CardType cardType = CardType.Unknown)
    {
        _cardType = cardType;
        int[] result = new int[cardNumber.Length];
        for (int i = 0; i < cardNumber.Length; i++)
        {
            result[i] = int.Parse(cardNumber[i].ToString());
        }
        CardNumber = result;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("# " + _cardType.ToString());
        sb.Append(" # card_number = \"");
        foreach (var integer in _cardNumber)
        {
            sb.Append(integer);
        }
        sb.Append("\"");
        return sb.ToString();
    }
}