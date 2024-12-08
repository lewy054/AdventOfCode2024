namespace Day5;

public class Part1(List<PageOrderingRule> pageOrderingRules, List<List<int>> listOfPageNumbersOfEachUpdate)
{
    public int Resolve()
    {
        var updatesInRightOrder = new List<List<int>>();
        foreach (var pageNumbersOfEachUpdate in listOfPageNumbersOfEachUpdate)
        {
            var wasInRightOrder = true;
            for (var i = 0; i < pageNumbersOfEachUpdate.Count; i++)
            {
                var pageNumber = pageNumbersOfEachUpdate[i];
                var numbersThatMustBeAfterPageNumber = pageOrderingRules
                    .Where(e => e.NumberToBeBefore == pageNumber)
                    .Select(e => e.NumberToBeAfter)
                    .ToList();
                var numbersThatMustBeBeforePageNumber = pageOrderingRules
                    .Where(e => e.NumberToBeAfter == pageNumber)
                    .Select(e => e.NumberToBeBefore)
                    .ToList();
                var numbersInUpdateBeforeCurrentPageNumber = pageNumbersOfEachUpdate
                    .Take(i - 1)
                    .ToList();
                var numbersInUpdateAfterCurrentPageNumber = pageNumbersOfEachUpdate
                    .Skip(i)
                    .Take(pageNumbersOfEachUpdate.Count - i)
                    .ToList();

                if (numbersInUpdateBeforeCurrentPageNumber.Any(e =>
                        numbersThatMustBeAfterPageNumber.Any(z => z == e)) ||
                    numbersInUpdateAfterCurrentPageNumber.Any(e =>
                        numbersThatMustBeBeforePageNumber.Any(z => z == e)))
                {
                    wasInRightOrder = false;
                    break;
                }
            }

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