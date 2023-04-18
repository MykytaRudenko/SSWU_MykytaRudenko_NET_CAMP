namespace Exercise1;

public static class GrahamScannner
{
    public static List<Point> ConvexHull(List<Point> points)
    {
        if (points == null || points.Count < 3)
        {
            throw new ArgumentException("At least 3 points required", nameof(points));
        }
    
        // шукає початкову точку
        Point anchor = points[0];
        foreach (Point p in points.Skip(1))
        {
            if (p.Y < anchor.Y || (p.Y == anchor.Y && p.X < anchor.X))
            {
                anchor = p;
            }
        }
    
        // сортує точки за кутом та довжиною від початкової точки
        List<Point> sorted = points.OrderBy(p => p, new PointComparer(anchor)).ToList();
    
        // будує обгортку
        Stack<Point> hull = new Stack<Point>();
        hull.Push(sorted[0]);
        hull.Push(sorted[1]);
        for (int i = 2; i < sorted.Count; i++)
        {
            Point top = hull.Pop();
            while (Orientation(hull.Peek(), top, sorted[i]) <= 0)
            {
                top = hull.Pop();
            }
            hull.Push(top);
            hull.Push(sorted[i]);
        }
        hull.Push(sorted[0]);
        return hull.Reverse().ToList();
    }
    
    private static double Orientation(Point p1, Point p2, Point p3)
    {
        double val = (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
        return val;
    }
}