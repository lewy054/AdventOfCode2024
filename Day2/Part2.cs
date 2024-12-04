using Infrastructure;

namespace Day2;

public class Part2(string inputFile)
{
    public int Resolve()
    {
        var input = FileHelpers.GetFileContent(inputFile);
        var numberOfSafeReports = 0;
        foreach (var reportLine in input)
        {
            var levels = reportLine.Split(' ').Select(int.Parse).ToList();
            var report = new Report(levels);
            if (report.IsReportSafeWithDampener())
            {
                numberOfSafeReports += 1;
            }
        }

        return numberOfSafeReports;
    }
}