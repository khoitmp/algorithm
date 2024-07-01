namespace Algorithm.Test;

[TestClass]
public class BinarySearchingTest
{
    [TestMethod]
    public void BinarySearchTest()
    {
        int[] intArray = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
        string[] stringArray = { "apple", "banana", "cherry", "date", "fig", "grape" };

        int intTarget = 7;
        string stringTarget = "date";

        int intIterativeResult = BinarySearch.BinarySearchIterative(intArray, intTarget);
        int intRecursiveResult = BinarySearch.BinarySearchRecursive(intArray, intTarget, 0, intArray.Length - 1);

        int stringIterativeResult = BinarySearch.BinarySearchIterative(stringArray, stringTarget);
        int stringRecursiveResult = BinarySearch.BinarySearchRecursive(stringArray, stringTarget, 0, stringArray.Length - 1);

        Xunit.Assert.Equal(3, intIterativeResult);
        Xunit.Assert.Equal(3, intRecursiveResult);
        Xunit.Assert.Equal(3, stringIterativeResult);
        Xunit.Assert.Equal(3, stringRecursiveResult);
    }
}