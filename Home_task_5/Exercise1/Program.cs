using Exercise1;

List<Point> trees = new List<Point>()
{
    new Point(3.4, 32.5),
    new Point(-3.0, 55.3),
    new Point(10, -23.3),
    new Point(-12.56, 0),
    new Point(10, -3.67),
    new Point(4, 0),
    new Point(-30, -20)
};
Fence fence = new Fence(trees);
Console.WriteLine(fence);
