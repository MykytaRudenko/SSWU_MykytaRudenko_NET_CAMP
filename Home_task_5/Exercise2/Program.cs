using Exercise2;

Box milk = new Box("milk", new Product(3d, 5d, 9d));
Box cheese = new Box("cheese", new Product(2d, 5d, 3d));
Box department = new Box("Milk products", milk, cheese);

Box supermarket = new Box("Atb", department);

Console.WriteLine(supermarket);
Console.ResetColor();