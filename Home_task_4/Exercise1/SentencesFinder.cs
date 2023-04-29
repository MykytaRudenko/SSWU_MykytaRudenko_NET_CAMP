namespace Exercise1;

public static class SentencesFinder
{
    public static List<string> FindSentenceWithSymbols(List<string> text, char firstSpecialSymbol,
        char secondSpecialSymbol, params char[] punctuations)
    {
        List<string> finalSentences = new List<string>();
        List<string> tempSentence = new List<string>();
        int startIndex;
        int endIndex;
        int lenght;
        foreach (var line in text)
        {
            lenght = line.Length;
            startIndex = 0;
            while ((endIndex = line.IndexOfAny(punctuations, startIndex)) != -1)
            {
                tempSentence.Add(line.Substring(startIndex, endIndex - startIndex + 1).Trim());
                if (CheckSymbols(tempSentence, firstSpecialSymbol, secondSpecialSymbol))
                {
                    finalSentences.AddRange(tempSentence.Where(s => !string.IsNullOrEmpty(s)));
                }
                startIndex = endIndex + 1;
                tempSentence.Clear();
            }
            tempSentence.Add(line.Substring(startIndex, lenght - startIndex).Trim());
        }
        return finalSentences;
    }
    // Добре, що для довільних символів.
    // А якщо є відкриваюча, а немає закриваючої дужки?
    private static bool CheckSymbols(List<string> lines, char firstSpecialSymbol, char secondSpecialSymbol)
    {
        bool isFirstSymbolExist = false;
        bool isSecondSymbolExist = false;
        foreach (var line in lines)
        {
            if (line.IndexOf(firstSpecialSymbol) != -1)
            {
                isFirstSymbolExist = true;
            }
            if (line.IndexOf(secondSpecialSymbol) != -1)
            {
                isSecondSymbolExist = true;
            }
        }
        return isFirstSymbolExist && isSecondSymbolExist;
    }
}
