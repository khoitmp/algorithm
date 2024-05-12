using System;
using System.Collections.Generic;

namespace Algorithm.Lib
{
    public class BinarySearchTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        /*

            === EXAMPLE BINARY SEARCH TREE ===

                            8
                        /     \ 
                    3          10
                    /   \       /   \
                    1     6     9    14
                        / \         /  \
                        4   7       13  15
                                    /
                                11
                                    \
                                    12

                            8
                        /     \ 
                    3          10
                    /   \       /  \
                    1     6     9   14
                        / \       /  \
                        4   7    null 15                            

        */

        private BinarySearchTreeNode<T> Root { get; set; }
        public int Count { get; private set; }

        #region Add
        /// <summary>
        /// Add the provided value to the binary tree
        /// - Time complexity
        ///     Best: O(logn) => In case the binaray tree is balanced
        ///     Worst: O(n) => In case the binary tree is unbalanced (a linked list)
        ///     Average: O(logn)
        /// </summary>
        public void Add(T value)
        {
            // Case 1: The tree is empty - allocate the head
            if (Root == null)
            {
                Root = new BinarySearchTreeNode<T>(value);
            }
            // Case 2: The tree is not empty so find the right location to insert
            else
            {
                AddTo(Root, value);
            }

            Count++;
        }

        // Recursive add algorithm
        private void AddTo(BinarySearchTreeNode<T> node, T value)
        {
            // Case 1: Value is less than the current node value
            if (value.CompareTo(node.Value) < 0)
            {
                // If there is no left child make this the new left
                if (node.Left == null)
                {
                    node.Left = new BinarySearchTreeNode<T>(value);
                }
                // Else add it to the left node
                else
                {
                    AddTo(node.Left, value);
                }
            }
            // Case 2: Value is equal to or greater than the current value
            else
            {
                // If there is no right, add it to the right
                if (node.Right == null)
                {
                    node.Right = new BinarySearchTreeNode<T>(value);
                }
                // Else add it to the right node
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }
        #endregion

        #region Remove
        /// <summary>
        /// Remove the first occurance of the specified value from the tree
        /// - Time complexity
        ///     Best: O(logn) => In case the binaray tree is balanced
        ///     Worst: O(n) => In case the binary tree is unbalanced (a linked list)
        ///     Average: O(logn)
        /// </summary>
        /// <param name="value">The value to remove</param>
        /// <returns>True if the value was removed, false otherwise</returns>
        public bool Remove(T value)
        {
            /*
                There are 3 cases of removing(these cases just ideas, not mapped with the code below)
                1.Remove a node has no children - leaf node
                2.Remove a node has one child
                3.Remove a node has 2 children
            */

            BinarySearchTreeNode<T> current, parent;

            current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }

            Count--;

            // Case 1: If current has no right child, then current's left replaces current 
            // (look at example diagram 1, and asump we will remove [1] out of the tree)
            if (current.Right == null)
            {
                // It was a root
                if (parent == null)
                {
                    Root = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);

                    // If parent value is greater than current value
                    // make the current left child a left child of parent
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            // Case 2: If current's right child has no left child, then current's right child replaces current
            // (look at example diagram 2, and asump we will remove [10] out of the tree)
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    Root = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);

                    // If parent value is greater than current value
                    // make the current right child a left child of parent
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    // If parent value is less than current value
                    // make the current right child a right child of parent
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            // Case 3: If current's right child has a left child, replace current with current's right child's left-most child 
            // (look at example diagram 1, and asump we will remove [10] out of the tree)
            else
            {
                // Find the right's left-most child
                BinarySearchTreeNode<T> leftmost = current.Right.Left;
                BinarySearchTreeNode<T> leftmostParent = current.Right;

                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // The parent's left subtree becomes the leftmost's right subtree
                leftmostParent.Left = leftmost.Right;

                // Assign leftmost's left and right to current's left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                // It was the root
                if (parent == null)
                {
                    Root = leftmost;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);

                    // If parent value is greater than current value
                    // make leftmost the parent's left child
                    if (result > 0)
                    {
                        parent.Left = leftmost;
                    }
                    // If parent value is less than current value
                    // make leftmost the parent's right child
                    else if (result < 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Remove all items from the tree
        /// </summary>
        public void Clear()
        {
            Root = null;
            Count = 0;
        }
        #endregion

        #region Searching
        /// <summary>
        /// Determine if the specified value exists in the binary tree
        /// - Time complexity
        ///     Best: O(logn) => In case the binaray tree is balanced
        ///     Worst: O(n) => In case the binary tree is unbalanced (a linked list)
        ///     Average: O(logn)
        /// </summary>
        public bool Contains(T value)
        {
            // defer to the node search helper function.
            BinarySearchTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        /// <summary>
        /// Find and return the first node containing the specified value. If the value
        /// is not found, return null. Also return the parent of the found node (or null)
        /// which is used in remove
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <param name="parent">The parent of the found node (or null)</param>
        /// <returns>The found node (or null)</returns>
        private BinarySearchTreeNode<T> FindWithParent(T value, out BinarySearchTreeNode<T> parent)
        {
            // Now, try to find data in the tree
            BinarySearchTreeNode<T> current = Root;

            parent = null;

            // While we don't have a match
            while (current != null)
            {
                int result = current.CompareTo(value);

                // If the value is less than current, go left
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                // If the value is more than current, go right
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                // We have a match!
                else
                {
                    break;
                }
            }

            return current;
        }
        #endregion

        #region Depth-first Traversal
        /// <summary>
        /// Perform the provided action on each binary tree value in pre-order traversal order
        /// - Usage: Used in case we want to copy the exact structure of the tree to another
        /// - Time complexity
        ///     Best: O(n)
        ///     Worst: O(n)
        ///     Average: O(n)
        /// </summary>
        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, Root);
        }

        private void PreOrderTraversal(Action<T> action, BinarySearchTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        /// <summary>
        /// Perform the provided action on each binary tree value in in-order traversal order
        /// - Usage: Used in case we want to get a list values in order (smallest -> largest)
        /// - Time complexity
        ///     Best: O(n)
        ///     Worst: O(n)
        ///     Average: O(n)
        /// </summary>
        /// <param name="action">The action to perform</param>
        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, Root);
        }

        private void InOrderTraversal(Action<T> action, BinarySearchTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);
            }
        }

        /// <summary>
        /// Perform the provided action on each binary tree value in post-order traversal order
        /// - Usage: Used in case we want to delete all the children first then delete the root
        /// - Time complexity
        ///     Best: O(n)
        ///     Worst: O(n)
        ///     Average: O(n)
        /// </summary>
        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, Root);
        }

        private void PostOrderTraversal(Action<T> action, BinarySearchTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        /// <summary>
        /// Enumerate the values contains in the binary tree in in-order traversal order
        /// </summary>
        public IEnumerator<T> InOrderTraversal()
        {
            // This is a non-recursive algorithm using a stack to demonstrate removing
            // recursion to make using the yield syntax easier
            if (Root != null)
            {
                // Store the nodes we've skipped in this stack (avoids recursion)
                var stack = new Stack<BinarySearchTreeNode<T>>();

                BinarySearchTreeNode<T> current = Root;

                // When removing recursion we need to keep track of whether or not
                // we should be going to the left node or the right nodes next
                bool goLeftNext = true;

                // Start by pushing head onto the stack
                stack.Push(current);

                while (stack.Count > 0)
                {
                    // If we're heading left...
                    if (goLeftNext)
                    {
                        // Push everything but the left-most node to the stack
                        // we'll yield the left-most after this block
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    // in-order is left->yield->right
                    yield return current.Value;

                    // If we can go right then do so
                    if (current.Right != null)
                    {
                        current = current.Right;

                        // Once we've gone right once, we need to start going left again
                        goLeftNext = true;
                    }
                    // If we can't go right then we need to pop off the parent node
                    // so we can process it and then go to it's right node
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
        #endregion

        #region Breath-first Traversal
        /// <summary>
        /// Perform the provided action on each binary tree value in level-order traversal (start from level 0)
        /// - Time complexity
        ///     Best: O(n)
        ///     Worst: O(n)
        ///     Average: O(n)
        /// </summary>
        public void LevelOrderTraversal(Action<T> action)
        {
            if (Root == null)
            {
                return;
            }

            var queue = new Queue<BinarySearchTreeNode<T>>();

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                action(current.Value);

                if (current.Left != null)
                    queue.Enqueue(current.Left);

                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }
        #endregion

        #region Depth
        /// <summary>
        /// Get the depth of the binary tree
        /// </summary>
        public int GetDepth()
        {
            // (-1 for the root, begin from level 0)
            return CalculateDepth(Root) - 1;
        }

        /// <summary>
        /// Calculate the depth of the binary tree
        /// </summary>
        private int CalculateDepth(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            // Recursively calculate left's depth and right's depth
            int leftDepth = CalculateDepth(node.Left);
            int rightDepth = CalculateDepth(node.Right);

            // Depth of the tree is maximum depth of left or right subtree (+1 for current node)
            return Math.Max(leftDepth, rightDepth) + 1;
        }
        #endregion

        #region Sum
        /// <summary>
        /// Get the sum of all nodes in the tree
        /// </summary>
        public int GetSum()
        {
            return Sum(Root);
        }

        private int Sum(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            // Recursively sum the nodes in the left and right subtrees
            int sumLeft = Sum(node.Left);
            int sumRight = Sum(node.Right);

            // Return the sum of the current node and the sums of left and right subtrees
            return Convert.ToInt32(node.Value) + sumLeft + sumRight;
        }
        #endregion

        #region IEnumerable
        /// <summary>
        /// Return an enumerator that performs an in-order traversal of the binary tree
        /// </summary>
        /// <returns>The in-order enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        /// <summary>
        /// Return an enumerator that performs an in-order traversal of the binary tree
        /// </summary>
        /// <returns>The in-order enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}