using Exercise1;

List<string> text = new List<string>();
text.Add("Непотрібний текст ( текст ) ыа. лллллро");
text.Add("Привіт всім. Я Микита");
text.Add("я вчуся на курсі(Net Camp)");
text.Add("у компанії Sigma Software. Ось такі справи.");
text.Add("Ні, ліви. :(");
List<string> sentences = new List<string>(SentencesFinder.FindSentenceWithSymbols(text, '(', ')'));
foreach (var line in sentences)
{
    Console.WriteLine(line);
}