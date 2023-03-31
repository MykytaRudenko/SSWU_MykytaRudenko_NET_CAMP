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
    // метод, що запускає роботу вежі
    public void StartWork()
    {
        
    }
    // метод, що передає воду з вежі до користувачів за одиницю часу
    private void GetWaterToUsers()
    {
        
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("=+=+=+=+Інформація про користувачів+=+=+=+=\n");
        foreach (var user in _users)
        {
            sb.Append(user.ToString() + '\n');
        }
        sb.Append("=+=+=+=+Інформація про вежу+=+=+=+=\n");
        return sb.ToString();
    }
}