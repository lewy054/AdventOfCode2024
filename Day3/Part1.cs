using System.Text.RegularExpressions;
using Infrastructure;

namespace Day3;

public class Part1(string inputFile)
{
    public int Resolve()
    {
        var input = FileHelpers.GetFileContent(inputFile);
        var inputString = string.Join("", input);
        var matches = Regexes.MulText().Matches(inputString);
        var totalValue = 0;
        foreach (Match match in matches)
        {
            var values = Regexes.NumbersRegex().Matches(match.Value);
            var result = int.Parse(values[0].Value) * int.Parse(values[1].Value);
            totalValue += result;
        }

        return totalValue;
    }
    
}