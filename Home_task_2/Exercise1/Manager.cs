using System.Text;

namespace Exercise1;

public class Manager
{
    private WaterTower _waterTower;
    private List<User> _users;
    public Manager(WaterTower waterTower, params User[] users)
    {
        _waterTower = waterTower;
        _users = new List<User>(users);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("=+=+=+=Інформація про користувачів+=+=+=+=\n"");
        int i = 0;
        foreach (var user in _users)
        {
            
        }
        return sb.ToString();
    }
}