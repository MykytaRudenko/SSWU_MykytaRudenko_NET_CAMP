using Exercise1;
//Mykyta	Rudenko	 90	0	0	98	90	90	60	85,6. вітаю Вас у 2 турі.
List<Point> firstTrees = new List<Point>()
{
    new Point(3.4, 32.5),
    new Point(-3.0, 55.3),
    new Point(10, -23.3),
    new Point(-12.56, 0),
    new Point(10, -3.67),
    new Point(4, 0),
    new Point(-30, -20)
};
Fence firstFence = new Fence(firstTrees);
Console.WriteLine(firstFence);
Console.WriteLine("Length: " + firstFence.Length);
Console.WriteLine(new string('-', 50));

List<Point> secondTrees = new List<Point>()
{
    new Point(3.4, 32.5),
    new Point(-3, 55.3),
    new Point(10, -23.3),
    new Point(-12.56, 0)
};
Fence secondFence = new Fence(secondTrees);
Console.WriteLine(secondFence);
Console.WriteLine("Length: " + secondFence.Length);
Console.WriteLine(new string('-', 50));

Console.WriteLine("first fence > second fence: " + (firstFence > secondFence));
Console.WriteLine("first fence < second fence: " + (firstFence < secondFence));
