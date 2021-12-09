namespace Trees
{
    public class BinaryTree<T> where T : IComparable
    {
        Node<T> Root;

        #region Properties

        public int Count { get; private set; }

        #endregion

        #region Constructors

        public BinaryTree()
        {
            Root = null;
            Count = 0;
        }

        public BinaryTree(T[] data)
        {
            Count = 0;
            InsertRange(data);
        }

        #endregion

        #region Insertion Methods

        public void Insert(T item)
        {
            if (Root == null)
            {
                Root = new Node<T>(item);
                return;
            }

            InsertNodeUnder(item, Root);
            Count++;
        }

        void InsertNodeUnder(T item, Node<T> parent)
        {
            bool isGreaterThanParent = item.CompareTo(parent.Data) > 0;

            if (isGreaterThanParent)
            {
                if (parent.RightChild == null)
                {
                    parent.RightChild = new Node<T>(item);
                }
                else
                {
                    InsertNodeUnder(item, parent.RightChild);
                }
            }
            else
            {
                if (parent.LeftChild == null)
                {
                    parent.LeftChild = new Node<T>(item);
                }
                else
                {
                    InsertNodeUnder(item, parent.LeftChild);
                }
            }
        }

        public void InsertRange(T[] items)
        {
            foreach (var item in items)
            {
                Insert(item);
            }
        }

        #endregion

        #region Searching

        public bool Contains(T item)
        {
            return FindNodeUnder(item, Root);
        }

        bool FindNodeUnder(T item, Node<T> parent)
        {
            int comparison = item.CompareTo(parent.Data);

            // Found item
            if (comparison == 0)
                return true;

            bool isGreaterThanParent = comparison > 0;

            if (isGreaterThanParent)
            {
                if (parent.RightChild == null)
                {
                    return false;
                }
                else
                {
                    return FindNodeUnder(item, parent.RightChild);
                }
            }
            else
            {
                if (parent.LeftChild == null)
                {
                    return false;
                }
                else
                {
                    return FindNodeUnder(item, parent.LeftChild);
                }
            }
        }

        #endregion

        #region Sorting

        public T[] SortItems()
        {
            return GetInOrderTraversal();
        }

        public T[] GetPreOrderTraversal()
        {
            var array = new List<T>(Count);
            PreOrderTraversal(Root, array);

            return array.ToArray();
        }

        public T[] GetInOrderTraversal()
        {
            var array = new List<T>(Count);
            InOrderTraversal(Root, array);

            return array.ToArray();
        }

        public T[] GetPostOrderTraversal()
        {
            var array = new List<T>(Count);
            PostOrderTraversal(Root, array);

            return array.ToArray();
        }

        #endregion

        #region Traversing

        void PreOrderTraversal(Node<T> node, List<T> array)
        {
            if (node == null)
                return;

            // V-L-R
            array.Add(node.Data);
            PreOrderTraversal(node.LeftChild, array);
            PreOrderTraversal(node.RightChild, array);
        }

        void InOrderTraversal(Node<T> node, List<T> array)
        {
            if (node == null)
                return;

            // L-V-R
            InOrderTraversal(node.LeftChild, array);
            array.Add(node.Data);
            InOrderTraversal(node.RightChild, array);
        }

        void PostOrderTraversal(Node<T> node, List<T> array)
        {
            if (node == null)
                return;

            // L-R-V
            PostOrderTraversal(node.LeftChild, array);
            PostOrderTraversal(node.RightChild, array);
            array.Add(node.Data);
        }

        #endregion
    }

    public class Node<T> where T : IComparable
    {
        public T Data;

        public Node<T> Parent;
        public Node<T> LeftChild;
        public Node<T> RightChild;

        public Node(T data)
        {
            Data = data;
        }
    }
}
