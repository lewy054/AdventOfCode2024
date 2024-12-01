using Infrastructure;

namespace Day1;

public class Part2(string inputFile)
{
    public int Resolve()
    {
        var leftList = new List<int>();
        var rightList = new List<int>();
        var input = FileHelpers.GetFileContent(inputFile);
        foreach (var line in input)
        {
            var matchCollection = Regexes.NumbersRegex().Matches(line);
            leftList.Add(int.Parse(matchCollection[0].Value));
            rightList.Add(int.Parse(matchCollection[1].Value));
        }

        var totalSimilarityScore = 0;
        var alreadySeenNumbers = new Dictionary<int, int>();

        foreach (var rightNumber in rightList)
        {
            if (alreadySeenNumbers.TryGetValue(rightNumber, out var number))
            {
                totalSimilarityScore += number;
                continue;
            }
            var leftNumber = leftList.Count(e=> e == rightNumber);
            var similarity = rightNumber * leftNumber;
            totalSimilarityScore += similarity;
            alreadySeenNumbers.TryAdd(rightNumber, similarity);
        }

        return totalSimilarityScore;
    }
}