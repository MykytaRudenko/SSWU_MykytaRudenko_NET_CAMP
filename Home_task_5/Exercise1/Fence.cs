using System.Text;

namespace Exercise1;

// паркан
public class Fence
{
    private List<Point> _points;
    private List<Point> _fence;

    public Fence(List<Point> points)
    {
        _points = new List<Point>(points);
        _fence = new List<Point>(GrahamScannner.ConvexHull(_points));
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