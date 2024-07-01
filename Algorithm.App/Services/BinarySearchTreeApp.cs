namespace Algorithm.App;

public static class BinarySearchTreeApp
{
    public static void Run(string[] args)
    {
        var tree = new BinarySearchTree<int>();

        tree.Add(8);
        tree.Add(3);
        tree.Add(1);
        tree.Add(6);
        tree.Add(4);
        tree.Add(7);
        tree.Add(10);
        tree.Add(9);
        tree.Add(14);
        tree.Add(13);
        tree.Add(11);
        tree.Add(12);
        tree.Add(15);

        tree.PreOrderTraversal(Console.WriteLine);
        Console.WriteLine("===");
        tree.InOrderTraversal(Console.WriteLine);
        Console.WriteLine("===");
        tree.PostOrderTraversal(Console.WriteLine);
        Console.WriteLine("===");
        tree.LevelOrderTraversal(Console.WriteLine);
    }
}