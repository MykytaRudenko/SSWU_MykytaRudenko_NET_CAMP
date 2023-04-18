using Exercise2;
// Менеджер має вежу. І найбільш імовірно, що композиційно. Тому інше відношення має бути. Де і хто створює користувачів? Якщо у користувача немає жодного метода, то ним керує строго менеджер. Це не дуже перспективно керувати поведінкою кожного користувача.

string mainStr = "Wow word  wow wordwword   word, Word wow word";
string str = "wow word";
Console.WriteLine(mainStr);
Console.WriteLine(str);
Console.WriteLine("Індекс другого входження підстроки \"" + str +"\" у строку: " + StringsRefactor.SecondEntry(mainStr, str));
Console.WriteLine("Кількість слів з заголовною літерою: " + StringsRefactor.NumberOfCapitalizedWords(mainStr));
Console.WriteLine("Перероблений текст(замінено всі слова з подвоєнням): " + StringsRefactor.DoubleLetterToStr(mainStr, str));
