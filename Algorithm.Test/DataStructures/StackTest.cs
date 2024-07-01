namespace Algorithm.Test;

[TestClass]
public class StackTest
{
    [TestMethod]
    public void StackSuccessCasesTest()
    {
        foreach (int[] items in InitItems())
        {
            var stack = new Lib.Stack<int>();

            for (int i = 0; i < items.Length; i++)
            {
                Assert.AreEqual(stack.Count, i, "The stack count is off");

                stack.Push(items[i]);

                Assert.AreEqual(stack.Count, i + 1, "The stack count is off");
                Assert.AreEqual(items[i], stack.Peek(), "The recently pushed value is not peeking");
            }

            Assert.AreEqual(items.Length, stack.Count, "The end count was not as expected");

            for (int i = items.Length - 1; i >= 0; i--)
            {
                int expected = items[i];
                Assert.AreEqual(expected, stack.Peek(), "The peeked value was not expected");
                Assert.AreEqual(expected, stack.Pop(), "The popped value was not expected");
                Assert.AreEqual(i, stack.Count, "The popped value was not expected");
            }
        }
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void PopFromEmptyThrowsTest()
    {
        var stack = new Lib.Stack<int>();
        stack.Pop();
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void PopFromEmptyThrowsAfterPushTest()
    {
        var stack = new Lib.Stack<int>();
        stack.Push(1);
        stack.Pop();
        stack.Pop();
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void PeekFromEmptyThrowsTest()
    {
        var stack = new Lib.Stack<int>();
        stack.Peek();
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void PeekFromEmptyThrowsAfterPushTest()
    {
        var stack = new Lib.Stack<int>();
        stack.Push(1);
        stack.Pop();
        stack.Peek();
    }

    private object[] InitItems()
    {
        object[] items = new[]
                            {
                                new int[0],
                                new [] { 0 },
                                new [] { 0, 1 },
                                new [] { 0, 1, 2 },
                                new [] { 0, 1, 2, 3 },
                                new [] { 0, 1, 2, 3, 4 },
                            };
        return items;
    }
}