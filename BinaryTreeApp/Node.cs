using System;

namespace BinaryTreeApp
{
    public class Node
    {
        public int Value { get; set; }

        public Node Parent { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public BinaryTree Tree { get; }

        public Node(BinaryTree tree, Node parent, int value) {
            Tree = tree ?? throw new ArgumentNullException(nameof(tree));

            Parent = parent;
            Value = value;
        }
    }
}