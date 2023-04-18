namespace Exercise1;

public class PointComparer : IComparer<Point>
{
    private Point anchor;

    public PointComparer(Point anchor)
    {
        this.anchor = anchor;
    }

    public int Compare(Point p1, Point p2)
    {
        double angle1 = GetAngle(anchor, p1);
        double angle2 = GetAngle(anchor, p2);

        if (angle1 < angle2)
        {
            return -1;
        }
        else if (angle1 > angle2)
        {
            return 1;
        }
        else
        {
            double distance1 = GetDistance(anchor, p1);
            double distance2 = GetDistance(anchor, p2);
            if (distance1 < distance2)
            {
                return -1;
            }
            else if (distance1 > distance2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    private static double GetAngle(Point anchor, Point p)
    {
        double dx = p.X - anchor.X;
        double dy = p.Y - anchor.Y;
        return Math.Atan2(dy, dx);
    }

    private static double GetDistance(Point p1, Point p2)
    {
        double dx = p2.X - p1.X;
        double dy = p2.Y - p1.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}