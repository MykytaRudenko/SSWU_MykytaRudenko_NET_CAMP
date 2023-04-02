namespace Exercise1;

public static class Validation
{
    public static double CheckLessThanZero(double value)
    {
        if (value < 0d) return 0d;
        return value;
    }

    public static double CheckEqualsZero(double value)
    {
        if (value == 0d)
        {
            Console.WriteLine("Це не може бути нулем, тому значення замінено на 1.");
            return 1d;
        }
        return value;
    }
}