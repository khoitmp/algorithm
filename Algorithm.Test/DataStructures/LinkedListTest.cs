namespace Algorithm.Test;

[TestClass]
public class LinkedListTest
{
    [TestMethod]
    public void InitalizeEmptyTest()
    {
        var items = new Lib.LinkedList<int>();

        Assert.AreEqual(0, items.Count);
    }

    [TestMethod]
    public void AddHeadTest()
    {
        var items = new Lib.LinkedList<int>();

        for (int i = 1; i <= 5; i++)
        {
            items.AddHead(i);
            Assert.AreEqual(i, items.Count);
        }

        var expected = 5;
        foreach (int i in items)
        {
            Assert.AreEqual(expected--, i);
        }
    }

    [TestMethod]
    public void AddTailTest()
    {
        var items = new Lib.LinkedList<int>();

        for (int i = 1; i <= 5; i++)
        {
            items.AddTail(i);
            Assert.AreEqual(i, items.Count);
        }

        int expected = 1;
        foreach (int i in items)
        {
            Assert.AreEqual(expected++, i);
        }
    }

    [TestMethod]
    public void RemoveTest()
    {
        var remove1to10 = InitItems(1, 10);
        Assert.AreEqual(10, remove1to10.Count);

        for (int i = 1; i <= 10; i++)
        {
            Assert.IsTrue(remove1to10.Remove(i));
            Assert.IsFalse(remove1to10.Remove(i));
        }

        Assert.AreEqual(0, remove1to10.Count);

        var remove10to1 = InitItems(1, 10);
        Assert.AreEqual(10, remove10to1.Count);

        for (int i = 10; i >= 1; i--)
        {
            Assert.IsTrue(remove10to1.Remove(i));
            Assert.IsFalse(remove10to1.Remove(i));
        }

        Assert.AreEqual(0, remove10to1.Count);
    }

    [TestMethod]
    public void ContainsTest()
    {
        var items = InitItems(1, 10);

        for (int i = 1; i <= 10; i++)
        {
            Assert.IsTrue(items.Contains(i));
        }

        Assert.IsFalse(items.Contains(0));
        Assert.IsFalse(items.Contains(11));
    }

    private Lib.LinkedList<int> InitItems(int start, int end)
    {
        var items = new Lib.LinkedList<int>();
        for (int i = start; i <= end; i++)
        {
            items.AddTail(i);
        }
        return items;
    }
}