namespace Exercise3;
// Сумарний бал - 90.
public static class UniqueWordFinder
{
    static readonly char[] splitChars = { ' ', ',', '.', '!', '?', '\n' };
    public static IEnumerable<string> FindWords(string text)
    {// Не бачу змісту для функції обгортки.
        string[] words = SplitText(text.ToLower());
        List<string> uniqueWords = new List<string>();
        uniqueWords.Add(words[0]);
        yield return words[0];
        bool isUnique;
        for (int i = 1; i < words.Length; i++)
        {
            isUnique = true;
            for (int j = 0; j < uniqueWords.Count; j++)
            {
                if (words[i].Equals(uniqueWords[j]))
                {
                    isUnique = false;
                    break;
                }
            }
            if (isUnique)
            {
                uniqueWords.Add(words[i]);
                yield return words[i];
            }
        }
    }
    public static IEnumerable<string> SetFindWordsMethod(string text)
    {
        string[] words = SplitText(text.ToLower());
        HashSet<string> uniqueWords = new HashSet<string>();
        foreach (string word in words)
        {
            if (uniqueWords.Add(word))
            {
                yield return word;
            }
        }
    }
    private static string[] SplitText(string text)
    {
        return text.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
    }
}
