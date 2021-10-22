using System;
using System.Collections.Generic;

namespace BinaryTreeZigZagOrderLevelTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var tree = GetBinaryTree();

            var data = ZigzagLevelOrder(tree);

        }




        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {

            IList<IList<int>> result = new List<IList<int>>();

            if(root == null)
            {
                return result;
            }

            Queue<TreeNode> treeNodes = new Queue<TreeNode>();

            treeNodes.Enqueue(root);
            int depth = 0;


            while(treeNodes.Count > 0)
            {
                int size = treeNodes.Count;

                List<int> currentLevel = new List<int>();

                for (int i = 0; i < size; i++)
                {
                    TreeNode current = treeNodes.Dequeue();

                    if(depth % 2 == 0)
                    {
                        currentLevel.Add(current.val);
                    }
                    else
                    {
                        currentLevel.Insert(0,current.val);
                    }

                    

                    if (current.left != null)
                    {
                        treeNodes.Enqueue(current.left);
                    }

                    if(current.right != null)
                    {
                        treeNodes.Enqueue(current.right);
                    }

                }

                result.Add(currentLevel);
                depth++;

            }

            return result;

        }



        public static TreeNode GetBinaryTree()
        {
            try
            {
                TreeNode treeNode = new TreeNode(3);

                treeNode.left = new TreeNode(9);

                treeNode.right = new TreeNode(20, new TreeNode(15), new TreeNode(7));

                return treeNode;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }


    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}
