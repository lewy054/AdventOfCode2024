using System.Text.RegularExpressions;

namespace Infrastructure;

public static partial class Regexes
{
    [GeneratedRegex("\\d+")]
    public static partial Regex NumbersRegex();
    
    [GeneratedRegex(@"mul\(\d+,\d+\)")]
    public static partial Regex MulText();
    
    [GeneratedRegex(@"do\(\)", RegexOptions.RightToLeft)]
    public static partial Regex Do();
    
    [GeneratedRegex(@"don\'t\(\)", RegexOptions.RightToLeft)]
    public static partial Regex Dont();
}