using System;

namespace zad3
{
    public abstract class Tree
    {
    }

    public class TreeNode : Tree
    {
        public Tree Left { get; set; }
        public Tree Right { get; set; }
    }

    public class TreeLeaf : Tree
    {
    }

    public abstract class TreeVisitor
    {
        public void Visit(Tree tree)
        {
            if (tree is TreeNode node)
            {
                VisitNode(node);
            }

            if (tree is TreeLeaf leaf)
            {
                VisitLeaf(leaf);
            }
        }

        protected virtual void VisitNode(TreeNode node)
        {
            if (node != null)
            {
                Visit(node.Left);
                Visit(node.Right);
            }
        }

        protected virtual void VisitLeaf(TreeLeaf leaf)
        {
        }
    }

    public class TreeDepthVisitor : TreeVisitor
    {
        public int Depth { get; private set; }
        private int _currentDepth = -1;

        protected override void VisitLeaf(TreeLeaf leaf)
        {
            ++_currentDepth;
            Depth = Math.Max(_currentDepth, Depth);
            --_currentDepth;
        }

        protected override void VisitNode(TreeNode node)
        {
            ++_currentDepth;
            Visit(node.Left);
            Visit(node.Right);
            --_currentDepth;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}