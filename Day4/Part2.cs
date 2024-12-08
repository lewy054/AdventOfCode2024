using Infrastructure;

namespace Day4;

public class Part2(string inputFileName)
{
    private string[] WordSearch { get; set; } = File.ReadAllLines(inputFileName);
    private string WordToFind { get; } = "MAS";

    public int Resolve()
    {
        var wordToFindAppears = 0;
        for (var y = 0; y < WordSearch.Length; y++)
        {
            for (var x = 0; x < WordSearch[y].Length; x++)
            {
                if (WordSearch[y][x] != WordToFind[WordToFind.Length / 2])
                {
                    continue;
                }

                var wordSearch = new WordSearch(WordSearch);
                wordToFindAppears += wordSearch.GetWordOccurrencesInXShape(x, y, WordToFind);
            }
        }

        return wordToFindAppears;
    }
}