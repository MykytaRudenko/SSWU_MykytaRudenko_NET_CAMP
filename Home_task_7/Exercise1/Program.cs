using Exercise1;

var context = new TrafficLightsContext(new XCrossRoadStrategy(5000));
context.StartTraffic();
Console.WriteLine();
