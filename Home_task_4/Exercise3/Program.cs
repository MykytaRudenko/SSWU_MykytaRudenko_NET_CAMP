using System.Text;
using Exercise3;
// Тут постарався!
Console.OutputEncoding = Encoding.UTF8;
string path = @"D:\Work\SigmaSoftware\SSWU_MykytaRudenko_NET_CAMP\Home_task_4\Exercise3\consumedElectricity.txt";

QuarterFileManager manager = new QuarterFileManager(path);
Quarter quarter = manager.GetQuarter();
Console.WriteLine(quarter.ToString());
Console.WriteLine("Індекс людини, що не використовувала електроенергію: " + quarter.IndexOfUnusedUser());
Console.WriteLine("Прізвище людини з найбільшою заборгованістю: " + quarter.SurnameOfTheMostConsumed());
Console.WriteLine(quarter[0]);
