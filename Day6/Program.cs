using Day6;

const string fileName = "input.txt";
var input = File.ReadAllLines(fileName);
var part1 = new Part1(input);
var part1Result = part1.Resolve();
Console.WriteLine($"Results of Day6, Part1 : {part1Result}");

// var part2 = new Part2(input);
// var part2Result = part2.Resolve();
// Console.WriteLine($"Results of Day6, Part2 : {part2Result}");

