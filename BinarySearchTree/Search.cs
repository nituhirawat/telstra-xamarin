using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int value, Node left, Node right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }

    public class BinarySearchTree
    {
        public static bool IsValidBST(Node root)
        {

            if (root == null)
                return true;

            // check if right node value is less than equal to the parent node
            if (root.Right != null)
            {
                if (root.Right.Value <= root.Value)
                    return false;
            }

            //check if the left node value is greater than the parent node
            if (root.Left != null)
            {
                if (root.Left.Value > root.Value)
                    return false;
            }

            // call the function recursively to check for each node
            return (IsValidBST(root.Right) && IsValidBST(root.Left));

        }


        public static void Main(string[] args)
        {
            Node n4 = new Node(1, null, null);
            Node n5 = new Node(5, null, null);
            Node n6 = new Node(2, null, null);
            Node n7 = new Node(7, null, null);
            Node n1 = new Node(1, n4, n5);
            Node n3 = new Node(3, n6, n7);
            Node n2 = new Node(2, n1, n3);


            Console.WriteLine(IsValidBST(n2));
            Console.ReadLine();
        }
    }
}
