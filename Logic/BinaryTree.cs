using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public enum TraverseMethod
    {
        PreOrder,
        InOrder,
        PostOrder
    }

    public class BinaryTree<T> where T : IComparable<T>
    {
        private Node<T> _root;

        public int LevelsCount { get { return GetLevelsCount(_root); } }

        public BinaryTree() { }

        public void Add(T item)
        {
            if (_root == null)
            {
                _root = new Node<T>(item);
                return;
            }

            Node<T> currentNode = _root;
            Node<T> currentParentNode = null;

            while (currentNode != null)
            {
                currentParentNode = currentNode;
                currentNode = (item.CompareTo(currentNode.Data) < 0) ? currentNode.Left : currentNode.Right;
            }

            var newNode = new Node<T>(item);

            if (item.CompareTo(currentParentNode.Data) < 0)
            {
                currentParentNode.Left = newNode;
            }
            else
            {
                currentParentNode.Right = newNode;
            }
        }

        public bool Search(T input, out T output)
        {
            output = default(T);

            Node<T> node;
            Node<T> parentNode;

            if (!SearchNode(input, out node, out parentNode))
                return false;

            output = node.Data;

            return true;
        }

        private bool SearchNode(T input, out Node<T> node, out Node<T> parentNode)
        {
            node = parentNode = null;

            Node<T> currentNode = _root;
            Node<T> currentParentNode = null;

            while (currentNode != null && currentNode.Data.CompareTo(input) != 0)
            {
                currentParentNode = currentNode;
                currentNode = (input.CompareTo(currentNode.Data) < 0) ? currentNode.Left : currentNode.Right;
            }

            if (currentNode == null)
                return false;

            node = currentNode;
            parentNode = currentParentNode;

            return true;
        }

        public bool Remove(T item)
        {
            Node<T> node;
            Node<T> parentNode;

            if (!SearchNode(item, out node, out parentNode))
                return false;

            if (node.Left == null && node.Right == null)
            {
                RemoveLeaf(node, parentNode);
            }
            else if (node.Left != null && node.Right != null)
            {
                RemoveDoubleBranch(node, parentNode);
            }
            else
            {
                RemoveSingleBranch(node, parentNode);
            }

            node = null;

            return true;
        }

        private void RemoveLeaf(Node<T> node, Node<T> parentNode)
        {
            if (node == _root)
            {
                _root = null;
                return;
            }

            if (node.Data.CompareTo(parentNode.Data) < 0)
                parentNode.Left = null;
            else
                parentNode.Right = null;
        }

        private void RemoveSingleBranch(Node<T> node, Node<T> parentNode)
        {
            if (node == _root)
            {
                _root = _root.Left ?? _root.Right;
                return;
            }

            if (node.Data.CompareTo(parentNode.Data) < 0)
            {
                parentNode.Left = node.Left ?? node.Right;
            }
            else
            {
                parentNode.Right = node.Left ?? node.Right;
            }
        }

        private void RemoveDoubleBranch(Node<T> node, Node<T> parentNode)
        {
            // Find adjacent node to be placed instead of removed node
            Node<T> adjacentNode = GetAdjacentNode(node);

            if (node == _root)
            {
                adjacentNode.Right = _root.Right;
                _root = adjacentNode;
                return;
            }

            if (node.Data.CompareTo(parentNode.Data) < 0)
                parentNode.Left = adjacentNode;
            else
                parentNode.Right = adjacentNode;
        }

        // Return the node with the smallest data among the nodes with a bigger data
        // (Go one node right for bigger nodes, and then all the way left for the smallest of them)
        private static Node<T> GetAdjacentNode(Node<T> node)
        {
            Node<T> currentNode = node.Right;
            Node<T> currentParentNode = node;

            while (currentNode.Left != null)
            {
                currentParentNode = currentNode;
                currentNode = currentNode.Left;
            }

            currentParentNode.Left = currentNode.Right;

            return currentNode;
        }

        // Scan the whole tree, using the requested method, while 
        // sending each node's data to the input delegate (Action<T>)
        public void TraverseTree(Action<T> action, TraverseMethod method = TraverseMethod.InOrder)
        {
            Traverse(_root, action, method);
        }

        private void Traverse(Node<T> root, Action<T> action, TraverseMethod method)
        {
            switch (method)
            {
                case TraverseMethod.PreOrder:
                    TraversePreOrder(root, action);
                    break;
                case TraverseMethod.InOrder:
                    TraverseInOrder(root, action);
                    break;
                case TraverseMethod.PostOrder:
                    TraversePostOrder(root, action);
                    break;
                default:
                    break;
            }
        }

        private void TraversePreOrder(Node<T> root, Action<T> action)
        {
            if (root == null) return;
            action(root.Data);
            TraverseInOrder(root.Left, action);
            TraverseInOrder(root.Right, action);
        }

        private void TraverseInOrder(Node<T> root, Action<T> action)
        {
            if (root == null) return;
            TraverseInOrder(root.Left, action);
            action(root.Data);
            TraverseInOrder(root.Right, action);
        }

        private void TraversePostOrder(Node<T> root, Action<T> action)
        {
            if (root == null) return;
            TraverseInOrder(root.Left, action);
            TraverseInOrder(root.Right, action);
            action(root.Data);
        }

        private int GetLevelsCount(Node<T> root)
        {
            if (root == null) return 0;
            int leftCount = GetLevelsCount(root.Left);
            int rightCount = GetLevelsCount(root.Right);
            return Math.Max(leftCount, rightCount) + 1;
        }

        class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }

            public Node(T data)
            {
                Data = data;
                Left = Right = null;
            }
        }
    }
}
