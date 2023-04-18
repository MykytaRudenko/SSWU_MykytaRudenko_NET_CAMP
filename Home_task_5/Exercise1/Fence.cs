using System.Text;

namespace Exercise1;

// паркан
public class Fence
{
    private List<Point> _points;
    private List<Point> _fence;
    private double _length;
    public double  Length { get { return _length; } }
    public Fence(List<Point> points)
    {
        _points = new List<Point>(points);
        _fence = new List<Point>(GrahamScannner.ConvexHull(_points));
        _length = SumLength();
    }

    private double SumLength()
    {
        double sum = 0;
        for (int i = 1; i < _fence.Count; i++)
        {
            sum += GetDistance(_fence[i], _fence[i - 1]);
        }
        return sum;
    }
    private double GetDistance(Point p1, Point p2)
    {
        double dx = p2.X - p1.X;
        double dy = p2.Y - p1.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
    public static bool operator >(Fence a, Fence b)
    {
        return a.Length > b.Length;
    }

    public static bool operator <(Fence a, Fence b)
    {
        return !(a > b);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Fence:\n");
        foreach (var point in _fence)
        {
            sb.Append(point.ToString());
            sb.Append('\n');
        }
        return sb.ToString();
    }
}