using Infrastructure;

namespace Day4;

public class Part1(string inputFileName)
{
    private string[] WordSearch { get; set; } = File.ReadAllLines(inputFileName);
    private string WordToFind { get; } = "XMAS";

    public int Resolve()
    {
        var wordToFindAppears = 0;
        for (var y = 0; y < WordSearch.Length; y++)
        {
            for (var x = 0; x < WordSearch[y].Length; x++)
            {
                if (WordSearch[y][x] != WordToFind[0])
                {
                    continue;
                }

                var wordSearch = new WordSearch(WordSearch);
                wordToFindAppears += wordSearch.GetWordOccurrencesInAllDimensions(x, y, WordToFind);
            }
        }

        return wordToFindAppears;
    }
}