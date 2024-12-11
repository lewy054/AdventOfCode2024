namespace Day5;

public class PageOrderingRule(int numberToBeBefore, int numberToBeAfter)
{
    public int NumberToBeBefore { get; set; } = numberToBeBefore;
    public int NumberToBeAfter { get; set; } = numberToBeAfter;

    public static bool ValidateOrder(List<int> update, List<PageOrderingRule> rules)
    {
        for (var i = 0; i < update.Count; i++)
        {
            var currentPage = update[i];

            var mustBeAfter = rules
                .Where(rule => rule.NumberToBeBefore == currentPage)
                .Select(rule => rule.NumberToBeAfter)
                .ToList();
            var mustBeBefore = rules
                .Where(rule => rule.NumberToBeAfter == currentPage)
                .Select(rule => rule.NumberToBeBefore)
                .ToList();

            var precedingPages = update
                .Take(i)
                .ToList();
            var followingPages = update
                .Skip(i + 1)
                .ToList();

            if (precedingPages.Any(page => mustBeAfter.Contains(page)) ||
                followingPages.Any(page => mustBeBefore.Contains(page)))
            {
                return false;
            }
        }

        return true;
    }
}