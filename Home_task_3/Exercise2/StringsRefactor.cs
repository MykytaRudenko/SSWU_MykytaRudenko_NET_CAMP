namespace Exercise2;

public static class StringsRefactor
{
    public static int SecondEntry(string mainStr, string str)
    {
        int index = mainStr.IndexOf(str, mainStr.IndexOf(str) + 1);
        // Це лишнє. 0 -це реальний номер. Тому ввели користувача в оману.
        if (index == -1) return 0;
        return index;
    }
    // я б цей метод окремо не створювала. Просто одразу в 19 стрічку клала 14.
    private static string[] RemoveSpaces(string str)
    {
        return str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    }
    // кількість слів із заголовною літерою 
    public static int NumberOfCapitalizedWords(string mainStr)
    {
        string[] words = RemoveSpaces(mainStr);
        int counter = 0;
        foreach (var word in words)
        {
            if(char.IsUpper(word[0]))
            {
                counter++;
            }
        }
        return counter;
    }

    public static string DoubleLetterToStr(string mainStr, string str)
    {
        string[] words = RemoveSpaces(mainStr);

        for (int i = 0; i < words.Length; i++)
        {
            if (ContainsDoubleLetter(words[i]))
            {
                words[i] = str;
            }
        }
        // Втрачаємо вхідні пробільні символи.
        return string.Join(" ", words);
    }
    private static bool ContainsDoubleLetter(string word)
    {
        for (int i = 0; i < word.Length - 1; i++)
        {
            if (word[i] == word[i + 1])
            {
                return true;
            }
        }
        return false;
    }
}
