using System.Text;

namespace Exercise2;

public class EmailAddressChecker
{
    private List<string> _correctMails;
    private List<string> _notGoodMails;

    public EmailAddressChecker()
    {
        _correctMails = new List<string>();
        _notGoodMails = new List<string>();
    }
    public void CheckAddress(string mainStr)
    {
        string[] mailArray = mainStr.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        foreach (var mail in mailArray)
        {
            // if(IsValidEmailNetMethod(mail)) _correctMails.Add(mail);
            // else if (ContainAtSymbol(mail)) _notGoodMails.Add(mail);
            if (mail.IndexOf('@') != -1)
            {
                if (IsValidMail(mail))
                {
                    _correctMails.Add(mail);
                    continue;
                }
                _notGoodMails.Add(mail);
            }
        }
    }
    public bool IsValidEmailNetMethod(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    public bool ContainAtSymbol(string mail)
    {
        if (mail.IndexOf('@') != -1) return true;
        return false;
    }
    //TODO: create try catch
    public bool IsValidMail(string mail)
    {
        string[] domens = mail.Split('@');
        char firstSymbol = domens[0][0];
        char lastSymbol = domens[0][domens[0].Length - 1];
        if (firstSymbol == '.' || lastSymbol == '.') return false;
        foreach (var symbol in domens[0])
        {
            if (!((symbol >= '!' && symbol <= '9') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= '^' && symbol <= '~')))
            {
                return false;
            }
        }
        
        firstSymbol = domens[1][0];
        lastSymbol = domens[1][domens[1].Length - 1];
        if (firstSymbol == '.' || lastSymbol == '-') return false;
        foreach (var symbol in domens[1])
        {
            if (!((symbol >= '0' && symbol <= '9') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z') || symbol == '-' || symbol == '.'))
            {
                return false;
            }
        }
        
        return true;
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