namespace Exercise1;

public static class SentencesFinder
{
    public static List<string> FindSentenceWithSymbols(List<string> text, char firstSpecialSymbol,
        char secondSpecialSymbol)
    {
        List<string> sentence = new List<string>();
        List<string> tempSentence = new List<string>();
        int startIndex = 0;
        int endIndex = 0;
        int lenght;
        foreach (var line in text)
        {
            lenght = line.Length;
            startIndex = 0;
            endIndex = line.IndexOf('.');
            while (endIndex != -1)
            {
                tempSentence.Add(line.Substring(startIndex, endIndex - startIndex + 1));
                if (CheckSymbols(tempSentence, firstSpecialSymbol, secondSpecialSymbol))
                {
                    foreach (var tempLine in tempSentence)
                    {
                        sentence.Add(tempLine);
                    }
                }
                startIndex = endIndex + 1;
                endIndex = line.IndexOf('.', startIndex);
                tempSentence.Clear();
            }
            tempSentence.Add(line.Substring(startIndex, lenght - startIndex));
        }
        return sentence;
    }
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