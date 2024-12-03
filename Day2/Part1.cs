using Infrastructure;

namespace Day2;

public class Part1(string inputFile)
{
    public int Resolve()
    {
        var input = FileHelpers.GetFileContent(inputFile);
        var numberOfSafeReports = 0;
        foreach (var report in input)
        {
            var levels = report.Split(' ').Select(int.Parse).ToArray();
            ReportType? reportType = null;
            var isSafe = levels
                .Select((value, index) => CheckIfReportIsSafe(index, value, levels, ref reportType))
                .All(e => e);
            if (isSafe)
            {
                numberOfSafeReports += 1;
            }
        }

        return numberOfSafeReports;
    }

    private static bool CheckIfReportIsSafe(int index, int value, int[] levels, ref ReportType? reportType)
    {
        if (index + 1 == levels.Length)
        {
            return true;
        }

        var nextValue = levels[index + 1];
        if (value > nextValue && reportType == ReportType.Increasing ||
            value < nextValue && reportType == ReportType.Decreasing)
        {
            return false;
        }

        if (nextValue - value > 0 && nextValue - value <= 3)
        {
            reportType = ReportType.Increasing;
            return true;
        }

        if (value - nextValue > 0 && value - nextValue <= 3)
        {
            reportType = ReportType.Decreasing;
            return true;
        }

        return false;
    }

    private enum ReportType
    {
        Increasing,
        Decreasing
    }
}