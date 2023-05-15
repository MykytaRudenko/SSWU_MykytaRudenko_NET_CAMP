using Exercise1;

var context = new Context(new XStrategy(1000, 3000, 3000));

context.AddStrategy(new XStrategyMultiroads(2, 1000, 3000, 3000, 600));
context.StartTraffic();