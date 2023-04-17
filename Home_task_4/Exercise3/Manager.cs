namespace Exercise3;

public class QuarterFileManager
{
    private readonly string _path;
    public QuarterFileManager(string path)
    {
        _path = path;
    }
    public Quarter GetQuarter(double cost = 1.44f)
    {
        try
        {
            FileStream file = new FileStream(_path, FileMode.OpenOrCreate);
            StreamReader stream = new StreamReader(file);
            string line = stream.ReadLine();

            int id = GetId(line);
            User[] users = new User[GetNumberOfUsers(line)];
            string[] userLine = new string[7];

            for (int i = 0; i < users.Length; i++)
            {
                line = stream.ReadLine();
                userLine = line.Split(';');
                users[i] = new User(Convert.ToInt32(userLine[0]), userLine[1],
                    userLine[2], Convert.ToDouble(userLine[3]), Convert.ToDouble(userLine[4]),
                    Convert.ToDateTime(userLine[5]), Convert.ToDateTime(userLine[6]), Convert.ToDateTime(userLine[7]));
            }
            stream.Close();
            file.Close();
            return new Quarter(id, cost, users);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
            return null;
        }
    }
    private int GetId(string line)
    {
        int id = -1;
        int index = line.IndexOf(';');
        if (index != -1)
        {
            id = Convert.ToInt32(line.Substring(0, index));
        }
        return id;
    }
    private int GetNumberOfUsers(string line)
    {
        int numberOfUsers = 0;
        int index = line.IndexOf(';');
        if (index != -1)
        {
            numberOfUsers = Convert.ToInt32(line.Substring(index + 1, line.Length - index - 1));
        }
        return numberOfUsers;
    }
}