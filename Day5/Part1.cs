namespace Day5;

public class Part1(List<PageOrderingRule> pageOrderingRules, List<List<int>> listOfPageNumbersOfEachUpdate)
{
    public int Resolve()
    {
        var updatesInRightOrder = new List<List<int>>();
        foreach (var pageNumbersOfEachUpdate in listOfPageNumbersOfEachUpdate)
        {
            var wasInRightOrder = pageNumbersOfEachUpdate
                .Select(_ => PageOrderingRule.ValidateOrder(pageNumbersOfEachUpdate, pageOrderingRules))
                .All(isOrderedCorrectly => isOrderedCorrectly);

            if (wasInRightOrder)
            {
                updatesInRightOrder.Add(pageNumbersOfEachUpdate);
            }
        }

        var middlePageNumberFromCorrectlyOrderedUpdates = updatesInRightOrder
            .Select(e => e[e.Count / 2])
            .ToList();
        var result = middlePageNumberFromCorrectlyOrderedUpdates.Sum();

        return result;
    }
}