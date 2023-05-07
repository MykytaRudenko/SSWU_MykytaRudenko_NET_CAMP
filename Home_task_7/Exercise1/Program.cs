using Exercise1;

var context = new TrafficLightsContext(new XCrossRoadStrategy(2000));
context.StartTraffic();
Console.WriteLine();