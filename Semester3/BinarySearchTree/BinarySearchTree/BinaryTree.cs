using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BinaryTree <T> : IEnumerable<T> where T : IComparable
    {

        public Node Root;

        public BinaryTree(T value)
        {
            Root = new Node(value);
        }
		
        /// <summary>
        /// Search max element
        /// </summary>
        /// <param name="root">root of tree</param>
        /// <returns>preferens on max element</returns>
        private static Node SearchMaxElement(Node root)
        {
            if (root.Right != null) return SearchMaxElement(root.Right);
            return root;
        }

        private static Node GetRoot(Node node)
        {
            if (node.Parent != null) return GetRoot(node.Parent);
            return node;
        }

        /// <summary>
        /// Add element ell in tree with root "root"
        /// </summary>
        /// <param name="root">root of tree</param>
        /// <param name="ell">element</param>
        public void Add(Node root, T ell)
        {
            if (ell.CompareTo(root.Value) >= 0)
            {
                if (root.Right == null)
                {
                    root.Right = new Node(ell)
                    {
                        Parent = root
                    };

                    root.Right.Parent = root;
                }
                else Add(root.Right, ell);
            }
            else
            {
                if (root.Left == null)
                {
                    root.Left = new Node(ell)
                    {
                        Parent = root
                    };
                }
                else Add(root.Left, ell);
            }
        }

        /// <summary>
        /// check included ell in tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="ell"></param>
        /// <returns></returns>
        public static Node SearchElement(Node root, T ell)
        {
            if (ell.CompareTo(root.Value) == 0) return root;
            if (ell.CompareTo(root.Value) == 1)
            {
                if (root.Right == null) return null;
                SearchElement(root.Right, ell);
            }
            if (root.Left == null) return null;
            SearchElement(root.Left, ell);
            return null;
        }

        /// <summary>
        /// delete node
        /// </summary>
        /// <param name="node">node which we will be delete</param>
        /// <returns>new root</returns>
        public static Node Delete(Node node)
        {

            if (node.Parent == null)
            {
                if (node.Left == null)
                {
                    if (node.Right == null) return null;
                    node.Right.Parent = null;
                    return node.Right;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Left.Parent = null;
                        return node.Left;
                    }
                    Node b = node;

                    node = SearchMaxElement(node.Left);
                    if (node.Parent == b)
                    {
                        node.Parent = null;
                        node.Right = b.Right;
                        return node;
                    }
                    node.Parent = null;
                    node.Left = b.Left;
                    node.Right = b.Right;
                    return node;
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
                return GetRoot(node);
            }

            if (node.Left == null)
            {
                node.Right.Parent = node.Parent;
                if (node == node.Parent.Left) node.Parent.Left = node.Right;
                else node.Parent.Right = node.Right;
                return GetRoot(node.Parent);
            }
            if (node.Right == null)
            {
                node.Left.Parent = node.Parent;
                if (node == node.Parent.Left) node.Parent.Left = node.Left;
                else node.Parent.Right = node.Left;
                return GetRoot(node.Parent);
            }
            Node a = node;
            node = SearchMaxElement(node.Left);
            if (node.Parent == a)
            {
                node.Parent = null;
                node.Right = a.Right;
                return node;
            }
            node.Parent = null;
            node.Left = a.Left;
            node.Right = a.Right;
            return GetRoot(node.Parent);
        }

        /// <summary>
        /// Reilized for IEnumerable
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return new TreeEnumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>) GetEnumerator();
        }

        /// <summary>
        /// Realized for IEnumerator
        /// </summary>
        private class TreeEnumerator : IEnumerator<T>
        {
            private int _position;

            private List<T> _list;
            //private IEnumerator<T> _enumeratorImplementation;

            public TreeEnumerator(BinaryTree<T> currentTree)
            {
                _position = -1;
                _list = new List<T>();
                RewriteInList(currentTree.Root);
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
                return (_position < _list.Count);
            }
			
            public void Dispose()
            {
                //throw new NotImplementedException();
            }
        }
		
        /// <summary>
        /// Class which realise elements for tree
        /// </summary>
        public class Node
        {
            public T Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }
    }
}