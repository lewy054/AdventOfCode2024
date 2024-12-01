using System.Text.RegularExpressions;
using Infrastructure;

namespace Day1;

public partial class Part1(string inputFile)
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

        var sortedLeftList = leftList.Order().ToList();
        var sortedRightList = rightList.Order().ToList();

        var distances = sortedLeftList.Select((t, i) => Math.Abs(sortedRightList[i] - t)).ToList();
        var result = distances.Sum();
        return result;
    }
}