using System;
using Trees;

namespace MyNamespace
{
    class Program
    {
        static void Main()
        {
            var tree = new BinaryTree<string>();

            tree.InsertRange(new string[]
            {
                "Apple",
                "Zebra",
                "Banana",
                "Juice",
                "Crown"
            });

            CheckSearching(tree);
            CheckTraversal(tree);
        }

        static void CheckSearching(BinaryTree<string> tree)
        {
            Console.WriteLine("Tree contains Apple: " + tree.Contains("Apple"));
            Console.WriteLine("Tree contains Banana: " + tree.Contains("Banana"));
            Console.WriteLine("Tree contains Pear: " + tree.Contains("Pear"));

            Console.WriteLine();
        }

        static void CheckTraversal(BinaryTree<string> tree)
        {
            Console.WriteLine("Printing in-order items: ");
            var items = tree.GetInOrderTraversal();

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
