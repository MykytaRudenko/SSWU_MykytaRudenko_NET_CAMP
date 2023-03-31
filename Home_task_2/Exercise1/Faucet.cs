using System.Text;

namespace Exercise1;

public class Faucet
{
    private bool _isOpen;

    public Faucet(bool isOpen = false)
    {
        _isOpen = isOpen;
    }
    public void Turn()
    {
        
    }
    public void Turn(bool isOpen)
    {
        
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Відкритий: " + _isOpen);
        return sb.ToString();
    }
}