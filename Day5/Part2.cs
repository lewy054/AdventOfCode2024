namespace Day5;

public class Part2(List<PageOrderingRule> pageOrderingRules, List<List<int>> listOfPageNumbersOfEachUpdate)
{
    public int Resolve()
    {
        var updatesInBadOrder = new List<List<int>>();

        foreach (var pageNumbersOfEachUpdate in listOfPageNumbersOfEachUpdate)
        {
            var wasInRightOrder = pageNumbersOfEachUpdate
                .Select(_ => PageOrderingRule.ValidateOrder(pageNumbersOfEachUpdate, pageOrderingRules))
                .All(isOrderedCorrectly => isOrderedCorrectly);

            if (!wasInRightOrder)
            {
                updatesInBadOrder.Add(pageNumbersOfEachUpdate);
            }
        }


        var sortedUpdates = new List<List<int>>();

        foreach (var pageNumbers in updatesInBadOrder)
        {
            var isOrdered = false;
            while (!isOrdered)
            {
                isOrdered = true;
                foreach (var rule in pageOrderingRules)
                {
                    var indexBefore = pageNumbers.IndexOf(rule.NumberToBeBefore);
                    var indexAfter = pageNumbers.IndexOf(rule.NumberToBeAfter);

                    if (indexBefore == -1 || indexAfter == -1 || indexBefore <= indexAfter)
                    {
                        continue;
                    }

                    pageNumbers.RemoveAt(indexBefore);
                    pageNumbers.Insert(indexAfter, rule.NumberToBeBefore);
                    isOrdered = false;
                }
            }

            sortedUpdates.Add(pageNumbers);
        }

        var middlePageNumbers = sortedUpdates.Select(update => update[update.Count / 2]).ToList();
        return middlePageNumbers.Sum();
    }
}