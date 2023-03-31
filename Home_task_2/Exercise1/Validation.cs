namespace Exercise1;

public static class Validation
{
    public static double CheckLessThanZero(double value)
    {
        if (value < 0f) return 0f;
        return value;
    }

    public static double CheckEqualsZero(double value)
    {
        if (value == 0)
        {
            Console.WriteLine("Це не може бути нулем, тому значення замінено на 1.");
            return 1f;
        }
        return value;
    }
}