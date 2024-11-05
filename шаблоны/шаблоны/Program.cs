using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace шаблоны
{

    public class Node<T> where T : IComparable
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
    public class BinaryTree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }
        public BinaryTree()
        {
            Root = null;
        }
        public void Insert(T data)
        {
            Root = Insert(Root, data);
        }
        private Node<T> Insert(Node<T> node, T data)
        {
            if (node == null)
            {
                return new Node<T>(data);
            }

            if (data.CompareTo(node.Data) < 0)
            {
                node.Left = Insert(node.Left, data);
            }
            else if (data.CompareTo(node.Data) > 0)
            {
                node.Right = Insert(node.Right, data);
            }

            return node;
        }
        public void RemoveSubtree(T max)
        {
            Root = RemoveSubtree(Root, max);
        }

        private Node<T> RemoveSubtree(Node<T> node, T max)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data.CompareTo(max) > 0)
            {
                
                return null;
            }

            node.Left = RemoveSubtree(node.Left, max);
            node.Right = RemoveSubtree(node.Right, max);

            return node;
        }

        public void PreorderTraversal()
        {
            PreorderTraversal(Root);
        }

        private void PreorderTraversal(Node<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " ");
                PreorderTraversal(node.Left);
                PreorderTraversal(node.Right);
            }
        }
        public void InorderTraversal()
        {
            InorderTraversal(Root);
        }

        private void InorderTraversal(Node<T> node)
        {
            if (node != null)
            {
                InorderTraversal(node.Left);
                Console.Write(node.Data + " ");
                InorderTraversal(node.Right);
            }
        }
        public void PostorderTraversal()
        {
            PostorderTraversal(Root);
        }

        private void PostorderTraversal(Node<T> node)
        {
            if (node != null)
            {
                PostorderTraversal(node.Left);
                PostorderTraversal(node.Right);
                Console.Write(node.Data + " ");
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            
            BinaryTree<int> intTree = new BinaryTree<int>();
            intTree.Insert(5);
            intTree.Insert(3);
            intTree.Insert(8);
            intTree.Insert(1);
            intTree.Insert(4);
            intTree.Insert(7);
            intTree.Insert(9);

            Console.WriteLine("Дерево целых чисел:");
            intTree.PreorderTraversal();
            Console.WriteLine();

            Console.Write("Введите максимальное значение для удаления поддерева: ");
            int max = int.Parse(Console.ReadLine());
            intTree.RemoveSubtree(max);

            Console.WriteLine("Дерево целых чисел после удаления поддерева:");
            intTree.PreorderTraversal();
            Console.WriteLine();

            BinaryTree<string> stringTree = new BinaryTree<string>();
            stringTree.Insert("apple");
            stringTree.Insert("banana");
            stringTree.Insert("cherry");
            stringTree.Insert("grape");
            stringTree.Insert("kiwi");

            Console.WriteLine("Дерево строк (инфиксный обход):");
            stringTree.InorderTraversal();
            Console.WriteLine();

            Console.Write("Введите максимальное значение для удаления поддерева: ");
            string maxString = Console.ReadLine();
            stringTree.RemoveSubtree(maxString);

            Console.WriteLine("Дерево строк после удаления поддерева (инфиксный обход):");
            stringTree.InorderTraversal();
            Console.WriteLine();
            Console.ReadKey ();
        }
    }
}
