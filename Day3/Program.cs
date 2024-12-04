using Day3;

const string fileName = "input.txt";

var part1 = new Part1(fileName);
var part1Result = part1.Resolve();
Console.WriteLine($"Results of Day3, Part1 : {part1Result}");

var part2 = new Part2(fileName);
var part2Result = part2.Resolve();
Console.WriteLine($"Results of Day3, Part2 : {part2Result}");