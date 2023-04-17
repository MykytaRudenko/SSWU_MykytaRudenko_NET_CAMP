using System.Text;

namespace Exercise3;

public class User
{
    private int _id;
    private string _address;
    private string _surname;
    public string Surname { get { return _surname; } }
    private double _startValue;
    private double _endValue;
    private DateTime _firstDate;
    public DateTime FirstDate { get { return _firstDate; } }
    private DateTime _secondDate;
    public DateTime SecondDate { get { return _secondDate; } }
    private DateTime _thirdDate;
    public DateTime ThirdDate { get { return _thirdDate; } }
    private double _consumed;
    public double Consumed { get { return _consumed; } }

    public User(int id, string address, string surname, 
        double startValue, double endValue, 
        DateTime firstDate, DateTime secondDate, DateTime thirdDate)
    {
        _id = id;
        _address = address;
        _surname = surname;
        _startValue = startValue;
        _endValue = endValue;
        _firstDate = firstDate;
        _secondDate = secondDate;
        _thirdDate = thirdDate;
        _consumed = _endValue - _startValue;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(String.Format("{0,-8}|", _id));
        sb.Append(String.Format("{0,-15}|", _surname));
        sb.Append(String.Format("{0,0:000,000.00}\t|{1,0:000,000.00}\t|", _startValue, _endValue));
        sb.Append(String.Format("{0:dd.MM.yy}\t|{1:dd.MM.yy}\t|{2:dd.MM.yy}\t|", _firstDate, _secondDate, _thirdDate));
        return sb.ToString();
    }
}