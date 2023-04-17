using System.Text;

namespace Exercise2;

    // зробив не статичним классом з статичним методом,
    // тому що потрібно повернути коректні адреси і ті,
    // що містять в своєму записі символ "@", але не є коректними(мінімум 2 колекції)
public class EmailAddressChecker
{
    private List<string> _correctMails;
    private List<string> _notGoodMails;
    public List<string> CorrectMails { get { return _correctMails; } }
    public List<string> NotGoodMails { get { return _notGoodMails; } }

    public EmailAddressChecker(string stringOfMails)
    {
        _correctMails = new List<string>();
        _notGoodMails = new List<string>();
        CheckAddress(stringOfMails);
    }
    private void CheckAddress(string text)
    {
        string[] mails = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int index;
        foreach (var mail in mails)
        {
            if ((index = mail.IndexOf('@')) != -1)
            {
                if (mail.IndexOf('@', index + 1) != -1)
                {
                    _notGoodMails.Add(mail);
                    continue;
                }
                if (IsValidMail(mail))
                {
                    _correctMails.Add(mail);
                    continue;
                }
                _notGoodMails.Add(mail);
            }
        }
    }
    
    // можна було реалізувати перевірку просто за допомогою System.Net.Mail.MailAddress
    
    // public bool IsValidEmailNetMethod(string email)
    // {
    //     try
    //     {
    //         var addr = new System.Net.Mail.MailAddress(email);
    //         return addr.Address == email;
    //     }
    //     catch
    //     {
    //         return false;
    //     }
    // }
    public bool IsValidMail(string mail)
    {
        string[] domens = mail.Split('@');
        try
        {
            char firstSymbol = domens[0][0];
            char lastSymbol = domens[0][domens[0].Length - 1];
            if (firstSymbol == '.' || lastSymbol == '.' || domens[0].Length > 64) return false;
            foreach (var symbol in domens[0])
            {
                if (!((symbol >= '!' && symbol <= '9') || (symbol >= 'A' && symbol <= 'Z') ||
                      (symbol >= '^' && symbol <= '~')))
                {
                    return false;
                }
            }
            firstSymbol = domens[1][0];
            lastSymbol = domens[1][domens[1].Length - 1];
            if (firstSymbol == '.' || lastSymbol == '-') return false;
            foreach (var symbol in domens[1])
            {
                if (!((symbol >= '0' && symbol <= '9') || (symbol >= 'A' && symbol <= 'Z') ||
                      (symbol >= 'a' && symbol <= 'z') || symbol == '-' || symbol == '.'))
                {
                    return false;
                }
            }
            return true;
        }
        catch (IndexOutOfRangeException ex)
        {
            return false;
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Correct emails:\n");
        foreach (var mail in _correctMails)
        {
            sb.Append(mail + '\n');
        }
        sb.Append("Other emails:\n");
        foreach (var mail in _notGoodMails)
        {
            sb.Append(mail + '\n');
        }
        return sb.ToString();
    }
}