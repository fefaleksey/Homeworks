using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Class which realise binary tree
    /// </summary>
    /// <typeparam name="T">T is type of value which we can put in tree</typeparam>
    public class BinaryTree <T> : IEnumerable<T> where T : IComparable
    {

        private Node _root;
        
        /// <summary>
        /// Constructor for tree
        /// </summary>
        /// <param name="value">value of root</param>
        /// <param name="empty">flag which show that we will create empty tree</param>
        public BinaryTree(T value, bool empty)
        {
            if (!empty)
            {
                _root = new Node(value);
            }
            else
            {
                _root = null;
            }
        }
		
        /// <summary>
        /// Search max element
        /// </summary>
        /// <param name="root">root of tree</param>
        /// <returns>referens on max element</returns>
        private static Node SearchMaxElement(Node root)
        {
            if (root.Right != null) 
                return SearchMaxElement(root.Right);
            return root;
        }

        private static Node GetRoot(Node node)
        {
            if (node.Parent != null)
            {
                return GetRoot(node.Parent);
            }
            return node;
        }

        /// <summary>
        /// Inserts an element with a value "value"
        /// </summary>
        /// <param name="value">value of element</param>
        public void Add(T value) => AddElement(_root, value);
        
        /// <summary>
        /// Add element "value" in tree with root "root"
        /// </summary>
        /// <param name="root">root of tree</param>
        /// <param name="value">element</param>
        private void AddElement(Node root, T value)
        {
            if (value.CompareTo(root.Value) >= 0)
            {
                if (root.Right == null)
                {
                    root.Right = new Node(value, root);
                    root.Right.Parent = root;
                }
                else
                {
                    AddElement(root.Right, value);
                }
            }
            else
            {
                if (root.Left == null)
                {
                    root.Left = new Node(value, root);
                }
                else
                {
                    AddElement(root.Left, value);
                }
            }
        }
        
        /// <summary>
        /// check included of element in tree
        /// </summary>
        /// <param name="value">value of element</param>
        /// <returns>reference to element</returns>
        public bool IsExist(T value) => SearchElement(_root, value) != null;

        /// <summary>
        /// check included element in tree
        /// </summary>
        /// <param name="root">root of tree</param>
        /// <param name="value">element</param>
        /// <returns>reference to element</returns>
        private Node SearchElement(Node root, T value)
        {
            if (value.CompareTo(root.Value) == 0)
            {
                return root;
            }
            if (value.CompareTo(root.Value) == 1)
            {
                if (root.Right == null) return null;
                {
                    return SearchElement(root.Right, value);
                }
            }
            if (root.Left == null)
            {
                return null;
            }
            return SearchElement(root.Left, value);
        }

        /// <summary>
        /// delete node with value "value"
        /// </summary>
        /// <param name="value">value of element which we will delete</param>
        public void Delete(T value)
        {
            var node = SearchElement(_root, value);
            if (node.Parent == null)
            {
                if (node.Left == null)
                {
                    if (node.Right == null)
                    {
                        _root = null;
                        return;
                    }
                    node.Right.Parent = null;
                    _root = node.Right;
                    return;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Left.Parent = null;
                        _root = node.Left;
                        return;
                    }
                    Node ancillary = node;

                    node = SearchMaxElement(node.Left);
                    if (node.Parent == ancillary)
                    {
                        node.Parent = null;
                        node.Right = ancillary.Right;
                        _root = node;
                        return;
                    }
                    node.Parent = null;
                    node.Left = ancillary.Left;
                    node.Right = ancillary.Right;
                    if (ancillary.Left != null)
                    {
                        ancillary.Left.Parent = node;
                    }
                    if (ancillary.Right.Parent != null)
                    {
                        ancillary.Right.Parent = node;
                    }
                    _root = node;
                    return;
                }
            }
            if (node.Left == null && node.Right == null)
            {
                if (node == node.Parent.Left)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
                return;
            }
            
            if (node.Left == null)
            {
                node.Right.Parent = node.Parent;
                if (node == node.Parent.Left)
                {
                    node.Parent.Left = node.Right;
                }
                else
                {
                    node.Parent.Right = node.Right;
                }
                return;
            }
            if (node.Right == null)
            {
                node.Left.Parent = node.Parent;
                if (node == node.Parent.Left)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }
                return;
            }
            Node auxiliary = node;
            node = SearchMaxElement(node.Left);
            node.Parent = auxiliary.Parent;
            node.Left = auxiliary.Left;
            node.Right = auxiliary.Right;
            if (node.Left != null)
            {
                node.Left.Parent = node;
            }
            if (node.Right.Parent != null)
            {
                node.Right.Parent = node;
            }
        }

        /// <summary>
        /// Reilize for IEnumerable
        /// </summary>
        public IEnumerator GetEnumerator() => new TreeEnumerator(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>) GetEnumerator();
        }

        /// <summary>
        /// Realize for IEnumerator
        /// </summary>
        private class TreeEnumerator : IEnumerator<T>
        {
            private int _position;

            private List<T> _list;

            public TreeEnumerator(BinaryTree<T> currentTree)
            {
                _position = -1;
                _list = new List<T>();
                RewriteInList(currentTree._root);
            }

            /// <summary>
            /// Take value from the tree in ascending order and write them in list
            /// </summary>
            private void RewriteInList(Node currentElement)
            {
                if (currentElement == null)
                {
                    return;
                }
                RewriteInList(currentElement.Left);
                _list.Add(currentElement.Value);
                RewriteInList(currentElement.Right);
            }

            public void Reset()
            {
                _position = -1;
            }

            T IEnumerator<T>.Current => _list[_position];

            public object Current => _list[_position];

            public bool MoveNext()
            {
                _position++;
                return _position < _list.Count;
            }
			
            public void Dispose()
            {
            }
        }
		
        /// <summary>
        /// Class which realise elements for tree
        /// </summary>
        private class Node
        {
            public T Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }

            public Node(T value)
            {
                Value = value;
            }
            
            public Node(T value, Node parent)
            {
                Value = value;
                Parent = parent;
            }
        }
    }
}