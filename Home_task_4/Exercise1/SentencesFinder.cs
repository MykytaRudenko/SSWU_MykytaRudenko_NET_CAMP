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
        bool isSymbolsExist;
        foreach (var line in text)
        {
            lenght = line.Length;
            startIndex = 0;
            endIndex = line.IndexOf('.');
            while (endIndex != -1)
            {
                // TODO: трабли з довжиною
                tempSentence.Add(line.Substring(startIndex, lenght - endIndex + 1));
                isSymbolsExist = CheckSymbols(tempSentence, firstSpecialSymbol, secondSpecialSymbol);
                if (isSymbolsExist)
                {
                    foreach (var l in tempSentence)
                    {
                        sentence.Add(l);
                    }
                }
                startIndex = endIndex + 2;
                endIndex = line.IndexOf('.', startIndex);
            }
            tempSentence.Clear();
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