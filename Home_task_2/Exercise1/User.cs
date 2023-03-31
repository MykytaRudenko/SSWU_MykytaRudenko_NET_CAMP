using System.Text;

namespace Exercise1;

public class User
{
    private string _name;
    public string Name { get { return _name; } }
    private string _surname;
    public string Surname { get { return _surname; } }
    private double _consuption;
    public double Consuption 
    { 
        get { return _consuption; }
        set { _consuption = value; }
    }
    private double _used;

    public double Used
    {
        get { return _used; }
        set { _used = value; }
    }
    public User(string name, string surname, double consuption)
    {
        _name = name;
        _surname = surname;
        _consuption = consuption;
        _used = 0f;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Ім'я користувача: " + _name + '\n');
        sb.Append("Прізвище: " + _surname + '\n');
        sb.Append("Використано/Потрібно: " + _used + '/' + _consuption + '\n');
        return sb.ToString();
    }
}