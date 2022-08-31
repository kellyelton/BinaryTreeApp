using System;
using System.Collections.Generic;

namespace BinaryTreeApp
{
    public class BinaryTree
    {
        public Node Root { get; private set; }

        public BinaryTree() {
        }

        public BinaryTree(int[] values) {
            foreach(var value in values) {
                Insert(value);
            };
        }

        public IEnumerable<Node> BetweenInclusive(Node nodeA, Node nodeB) {
            if (nodeA == null) throw new ArgumentNullException(nameof(nodeA));
            if (nodeB == null) throw new ArgumentNullException(nameof(nodeB));

            if (Root == null) yield break;

            if (nodeA.Tree != this) throw new ArgumentException($"{nameof(nodeA)}.{nameof(nodeA.Tree)} is not this {nameof(BinaryTree)}.", nameof(nodeA));
            if (nodeB.Tree != this) throw new ArgumentException($"{nameof(nodeB)}.{nameof(nodeB.Tree)} is not this {nameof(BinaryTree)}.", nameof(nodeB));

            if (nodeA.Value == nodeB.Value) {
                yield return nodeA;
                yield return nodeB;

                yield break;
            }

            Node startNode = null;
            Node endNode = null;
            Node currentNode = null;
            if(nodeB.Value > nodeA.Value) {
                startNode = currentNode = nodeB;
                endNode = nodeA;
            } else {
                startNode = currentNode = nodeA;
                endNode = nodeB;
            }

            while (currentNode != null) {
                yield return currentNode;

                if (currentNode.Value == endNode.Value) {
                    break;
                } else if (currentNode.Value < endNode.Value) {
                    currentNode = currentNode.Right;
                } else {
                    currentNode = currentNode.Left;
                }
            }
        }

        public Node Find(int value) {
            return FindIn(Root, value);
        }

        private Node FindIn(Node node, int value) {
            if (node == null) return null;
            if (node.Value == value) return node;

            if (value <= node.Left?.Value) {
                return FindIn(node.Left, value);
            }

            if (value <= node.Right?.Value) {
                return FindIn(node.Right, value);
            }

            return null;
        }

        public void Insert(int value) {
            Root = Insert(null, Root, value);
        }

        private Node Insert(Node parent, Node node, int v) {
            if (node == null) {
                node = new Node(this, parent, v);
            } else if (v < node.Value) {
                node.Left = Insert(node, node.Left, v);
            } else {
                node.Right = Insert(node, node.Right, v);
            }

            return node;
        }
    }
}
