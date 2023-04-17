using System.Text;

namespace Exercise3;

public class Quarter
{
    private int _id;
    private double _cost;
    private List<User> _users;

    public Quarter(int id, double cost, params User[] users)
    {
        _id = id;
        _cost = cost;
        _users = new List<User>(users);
    }

    public int IndexOfUnusedUser()
    {
        for (int i = 0; i < _users.Count; i++)
        {
            if (_users[i].Consumed == 0) return i;
        }
        return -1;
    }

    public string SurnameOfTheMostConsumed()
    {
        User maxConsumedUser = _users[0];
        foreach (var user in _users)
        {
            if (user.Consumed > maxConsumedUser.Consumed) maxConsumedUser = user;
        }
        return maxConsumedUser.Surname;
    }
    public User this [int i]
    {
        get => _users[i];
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Quarter " + _id + "\n");
        sb.Append($"ID\t|Surname\t|Start Value\t|End Value\t|");
        sb.Append(String.Format("{0,-15:MMMM}|{1,-15:MMMM}|{2,-15:MMMM}|",_users[0].FirstDate, _users[0].SecondDate, _users[0].ThirdDate));
        sb.Append("Duty        |Days Left|\n");
        sb.Append('-',128);
        sb.Append('\n');
        foreach (var user in _users)
        {
            sb.Append(user);
            sb.Append(String.Format("{0,12:C2}|", user.Consumed * _cost));
            sb.Append(String.Format("{0,9}|", DaysFromLastDate(user.ThirdDate)));
            sb.Append('\n');
        }
        return sb.ToString();
    }
    private int DaysFromLastDate(DateTime lastDate)
    {
        TimeSpan duration = DateTime.Now - lastDate;
        int days = duration.Days;
        return days;
    }
}