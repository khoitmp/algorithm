using System.Linq;
using Algorithm.Lib;

namespace Algorithm.Test
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void InsertTest()
        {
            var tree = new BinarySearchTree<int>();

            tree.Add(3);
            tree.Add(1);
            tree.Add(4);
            tree.Add(2);

            int[] expected = new int[] { 3, 1, 2, 4 };

            AssertTreePreOrder(tree, expected);
        }

        [TestMethod]
        public void RemoveLeafTest()
        {
            /*
                      3
                  1      4
                    2
            */

            var tree = new BinarySearchTree<int>();

            tree.Add(3);
            tree.Add(1);
            tree.Add(4);
            tree.Add(2);

            tree.Remove(2);
            AssertTreePreOrder(tree, new int[] { 3, 1, 4 });

            tree.Remove(4);
            AssertTreePreOrder(tree, new int[] { 3, 1 });

            tree.Remove(1);
            AssertTreePreOrder(tree, new int[] { 3 });
        }

        [TestMethod]
        public void RemoveOneChildRightTest()
        {
            /*
                      3
                  1      4
                    2
            */

            var tree = new BinarySearchTree<int>();

            tree.Add(3);
            tree.Add(1);
            tree.Add(4);
            tree.Add(2);
            tree.Remove(1);

            AssertTreePreOrder(tree, new int[] { 3, 2, 4 });
        }

        [TestMethod]
        public void RemoveOneChildLeftTest()
        {
            /*
                      3
                  2      4
                 1
            */

            var tree = new BinarySearchTree<int>();

            tree.Add(3);
            tree.Add(2);
            tree.Add(4);
            tree.Add(1);
            tree.Remove(2);

            AssertTreePreOrder(tree, new int[] { 3, 1, 4 });
        }

        [TestMethod]
        public void RemoveTwoChildTest()
        {
            /*
                      10
                  5       11
                 4  9
                3  7
                    8
            */

            var tree = new BinarySearchTree<int>();

            tree.Add(10);
            tree.Add(5);
            tree.Add(4);
            tree.Add(9);
            tree.Add(7);
            tree.Add(8);
            tree.Add(3);
            tree.Add(11);

            /*
                      10
                  7       11
                 4  9
                3  8
            */

            tree.Remove(5);

            AssertTreePreOrder(tree, new int[] { 10, 7, 4, 3, 9, 8, 11 });
        }

        [TestMethod]
        public void RemoveRootTwoChildTest()
        {
            /*
                      10
                  5        20
                4   6    15
                       12
                         13
                           14
            */

            var tree = new BinarySearchTree<int>();

            tree.Add(10);
            tree.Add(5);
            tree.Add(4);
            tree.Add(6);
            tree.Add(20);
            tree.Add(15);
            tree.Add(12);
            tree.Add(13);
            tree.Add(14);

            /*
                      12
                  5        20
                4   6    15
                       13
                         14
            
            */

            tree.Remove(10);

            AssertTreePreOrder(tree, new int[] { 12, 5, 4, 6, 20, 15, 13, 14 });

            /*
                      13
                  5        20
                4   6    15
                       14
            
            */

            tree.Remove(12);

            AssertTreePreOrder(tree, new int[] { 13, 5, 4, 6, 20, 15, 14 });
        }

        [TestMethod]
        public void RemoveRootOneChildLeftTest()
        {
            /*
                    3
                  2
                 1
            */

            var tree = new BinarySearchTree<int>();

            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Remove(3);

            AssertTreePreOrder(tree, new int[] { 2, 1 });
        }

        [TestMethod]
        public void RemoveRootOneChildRightTest()
        {
            /*
                      3
                        4
                          5
            */

            var tree = new BinarySearchTree<int>();

            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Remove(3);

            AssertTreePreOrder(tree, new int[] { 4, 5 });
        }

        [TestMethod]
        public void RemoveRootOnlyTest()
        {
            var tree = new BinarySearchTree<int>();

            tree.Add(3);
            tree.Remove(3);

            AssertTreePreOrder(tree, new int[] { });
        }

        [TestMethod]
        public void PreOrderCopyTreeTest()
        {
            /*
                      10
                  5        20
                4   6    15
                       12
                         13
                           14
            */

            var expected = new BinarySearchTree<int>();

            expected.Add(10);
            expected.Add(5);
            expected.Add(4);
            expected.Add(6);
            expected.Add(20);
            expected.Add(15);
            expected.Add(12);
            expected.Add(13);
            expected.Add(14);

            var actual = new BinarySearchTree<int>();

            expected.PreOrderTraversal((value) => actual.Add(value));

            AssertTreesSame(expected, actual);
        }

        [TestMethod]
        public void SumTreeTest()
        {
            var tree = new BinarySearchTree<int>();

            tree.Add(10);
            tree.Add(5);
            tree.Add(4);
            tree.Add(6);
            tree.Add(20);
            tree.Add(15);
            tree.Add(12);
            tree.Add(13);
            tree.Add(14);

            var sum = tree.GetSum();

            Assert.AreEqual(99, sum);
        }

        [TestMethod]
        public void DepthTreeTest()
        {
            var tree = new BinarySearchTree<int>();

            /*
                      10
                  5        20
                4   6    15
                       12
                         13
                           14
            */

            tree.Add(10);
            tree.Add(5);
            tree.Add(20);
            tree.Add(4);
            tree.Add(6);
            tree.Add(15);
            tree.Add(12);
            tree.Add(13);
            tree.Add(14);

            var depth = tree.GetDepth();

            Assert.AreEqual(5, depth);
        }

        private int[] TreeToPreorderArray(BinarySearchTree<int> tree)
        {
            var actualList = new DoublyLinkedList<int>();

            tree.PreOrderTraversal((value) => actualList.AddTail(value));

            return actualList.ToArray();
        }

        private void AssertTreesSame(BinarySearchTree<int> expected, BinarySearchTree<int> actual)
        {
            AssertArraysSame(TreeToPreorderArray(expected), TreeToPreorderArray(actual));
        }

        private void AssertArraysSame(int[] expected, int[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], string.Format("Incorrect value at index {0}", i));
            }
        }

        private void AssertTreePreOrder(BinarySearchTree<int> tree, int[] expected)
        {
            Assert.AreEqual(tree.Count, expected.Length, "Tree count was incorrect");

            int[] actual = TreeToPreorderArray(tree);

            AssertArraysSame(expected, actual);
        }
    }
}