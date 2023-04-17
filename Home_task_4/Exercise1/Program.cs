using System.Text;
using Exercise1;
Console.OutputEncoding = Encoding.UTF8;

List<string> text = new List<string>();
text.Add("Непотрібний текст з дужками (");
text.Add("текст )? Ще одне речення.");
text.Add("Привіт всім. Це текст. Я Микита,");
text.Add("я вчуся на курсі(Net Camp)");
text.Add("у компанії Sigma Software. Ось такі справи.");
text.Add("Ні, ліви. :(");

char[] punctuations = new char[] { '.', '!', '?' };
List<string> sentences = new List<string>(SentencesFinder.FindSentenceWithSymbols(text, '(', ')', punctuations));
foreach (var line in sentences)
{
    Console.WriteLine(line);
}

Console.WriteLine(new string('-', 50));
text.Clear();
text.Add("Certainly! Here is a sample text in");
text.Add("English with three sentences that contain parentheses:");
text.Add("The weather is perfect today (sunny and warm),");
text.Add("so I'm planning to go for a hike in the mountains? I'm attending");
text.Add("a conference next week (on artificial intelligence)");
text.Add("to learn about the latest advancements in the field.");
text.Add("She received a promotion at work");
text.Add("(which she has been working towards for years)");
text.Add("and is thrilled about the new opportunities!");

sentences = new List<string>(SentencesFinder.FindSentenceWithSymbols(text, '(', ')', punctuations));
foreach (var line in sentences)
{
    Console.WriteLine(line);
}