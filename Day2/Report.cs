namespace Day2;

public class Report(List<int> levels)
{
    public bool IsReportSafe()
    {
        ReportType? reportType = null;
        var isSafe = levels
            .Select((value, index) => IsNextValueSafe(levels, index, value, ref reportType))
            .All(e => e);
        return isSafe;
    }

    public bool IsReportSafeWithDampener()
    {
        ReportType? reportType = null;
        var levelQualityIndicators = levels
            .Select((value, index) => IsNextValueSafe(levels, index, value, ref reportType)).ToList();
        var countOfSafeReports = levelQualityIndicators.Where(e => e).ToList().Count;
        return countOfSafeReports == levels.Count || CheckBadLevelsForDampener(levelQualityIndicators);
    }

    private bool CheckBadLevelsForDampener(List<bool> results)
    {
        for (var i = 0; i < levels.Count; i++)
        {
            ReportType? reportType = null;
            var levelsWithoutOneLevel = levels.Where((_, index) => index != i).ToList();
            var levelQualityIndicators = levelsWithoutOneLevel
                .Select((value, index) => IsNextValueSafe(levelsWithoutOneLevel, index, value, ref reportType))
                .ToList();
            if (levelsWithoutOneLevel.Count == levelQualityIndicators.Count(e => e))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsNextValueSafe(List<int> levelsToCheck, int index, int value, ref ReportType? reportType)
    {
        if (index + 1 == levelsToCheck.Count)
        {
            return true;
        }

        var nextValue = levelsToCheck[index + 1];
        if (value > nextValue && reportType == ReportType.Increasing ||
            value < nextValue && reportType == ReportType.Decreasing ||
            nextValue == value)
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