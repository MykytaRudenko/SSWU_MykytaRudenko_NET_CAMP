using System.Text;
using Exercise3;

Console.OutputEncoding = Encoding.UTF8;

string text = "унікальні слова unique words, слова words\n наступна стрічка. Наступна фраза";
var uniqueWords = UniqueWordFinder.FindWords(text);

foreach (var item in uniqueWords)
{
    Console.Write(item + ", ");
}

Console.WriteLine('\n' + new string('-', 50));

uniqueWords = UniqueWordFinder.SetFindWordsMethod(text);
foreach (var item in uniqueWords)
{
    Console.Write(item + ", ");
}