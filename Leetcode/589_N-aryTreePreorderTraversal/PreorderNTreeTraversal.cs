// Given the root of an n-ary tree, return the preorder traversal of its nodes' values.
using System;
using System.Collections.Generic;

namespace PreOrderTraversalNs;

public class Node {
    public int val;
    public IList<Node> children;
    public Node(int value, IList<Node> children = null) {
        this.val = value;
        this.children = children;
    }
}

public class Solution
{
    /// <summary>
    /// Pre-order the N-ary tree
    /// </summary>
    public static IList<int> PreorderNTreeRecursively(Node root)
    {
        IList<int> result = new List<int>();

        PreorderRecursively(root, result);
        return result;
    }

    private static void PreorderRecursively(Node node, IList<int> result)
    {
        if (node == null)
          return;

        result.Add(node.val);

        if (node.children != null)
        {
            foreach (var child in node.children)
            {
                PreorderRecursively(child, result);
            }
        }       
    }

    public static void Main(string[] args)
    {
        {
            /*        1
                   /  |  \
                 3   2   4
               / \ 
              5  6
        */
            Node node3 = new Node(3, new List<Node>
                {
                    new Node(5),
                    new Node(6)
                });

            Node root = new Node(1, new List<Node>
                {
                    node3,
                    new Node(2),
                    new Node(4)
                });

            IList<int> result = PreorderNTreeRecursively(root);
            PrintPreorderList(result);
        }

        {
        /*      1
             / |  \  \
           2   3   4   5
              / \  |  /  \
             6   7 8  9  10
                 | |  |
                11 12 13
                 |
                14
        */

            Node node11 = new Node(11, new List<Node> { new Node(14) });
            Node node7 = new Node(7, new List<Node> { node11 });

            Node node3 = new Node(3, new List<Node>
                {
                    new Node(6),
                    node7
                });

            Node node8 = new Node(8, new List<Node> { new Node(12) });
            Node node4 = new Node(4, new List<Node> { node8 });

            Node node9 = new Node(9, new List<Node> { new Node(13) });
            Node node5 = new Node(5, new List<Node> { node9, new Node(10) });

            Node root = new Node(1, new List<Node>
                {
                    new Node(2),
                    node3,
                    node4,
                    node5
                });

            IList<int> result = PreorderNTreeRecursively(root);
            PrintPreorderList(result);
        }
    }

    private static void PrintPreorderList(IList<int> list)
    {
        Console.Write("Postorder: [");
        foreach (int i in list){
            Console.Write($"{i},");
        }
        Console.WriteLine("]");
    }
}