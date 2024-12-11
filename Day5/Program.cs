using Day5;

const string fileName = "input.txt";
var input = File.ReadAllLines(fileName);
var pageOrderingRules = input.TakeWhile(e => e != string.Empty).Select(e =>
{
    var numbers = e.Split('|').Select(int.Parse).ToList();
    return new PageOrderingRule(numbers[0], numbers[1]);
}).ToList();
var pageNumbers = input.Skip(pageOrderingRules.Count + 1).ToList();
var pageNumbersOfEachUpdate = pageNumbers
    .Select(pageNumber => pageNumber
        .Split(",").Select(int.Parse).ToList())
    .ToList();
var part1 = new Part1(pageOrderingRules, pageNumbersOfEachUpdate);
var part1Result = part1.Resolve();
Console.WriteLine($"Results of Day5, Part1 : {part1Result}");

var part2 = new Part2(pageOrderingRules, pageNumbersOfEachUpdate);
var part2Result = part2.Resolve();
Console.WriteLine($"Results of Day5, Part2 : {part2Result}");