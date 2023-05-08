using Exercise1;

var context = new Context(new XStrategyMultithreaded(1000, 5000));
context.StartTraffic();