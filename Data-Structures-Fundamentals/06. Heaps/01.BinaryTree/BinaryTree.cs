using System.Text;

namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            var result = PreOrder(this, new StringBuilder(), 0);

            return result;
        }

        private string PreOrder(IAbstractBinaryTree<T> node, StringBuilder result, int indent)
        {

            result.Append(new string(' ', indent)).Append(node.Value).Append(Environment.NewLine);

            if (node.LeftChild != null)
            {
                PreOrder(node.LeftChild, result, indent + 2);
            }
            if (node.RightChild != null)
            {
                //result += $"{node.Value}\r\n";

                PreOrder(node.RightChild, result, indent + 2);
            }

            return result.ToString().Trim();
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            return InOrderRecursion(this, new List<IAbstractBinaryTree<T>>());
        }
        private List<IAbstractBinaryTree<T>> InOrderRecursion(IAbstractBinaryTree<T> node, List<IAbstractBinaryTree<T>> result)
        {
            if (node.LeftChild != null)
            {
                InOrderRecursion(node.LeftChild, result);
            }
            result.Add(node);

            if (node.RightChild != null)
            {

                InOrderRecursion(node.RightChild, result);
            }

            return result;
        }


        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            return PostOrderRecursion(this, new List<IAbstractBinaryTree<T>>());
        }
        private List<IAbstractBinaryTree<T>> PostOrderRecursion(IAbstractBinaryTree<T> node, List<IAbstractBinaryTree<T>> result)
        {
            if (node.LeftChild != null)
            {
                PostOrderRecursion(node.LeftChild, result);
            }

            if (node.RightChild != null)
            {

                PostOrderRecursion(node.RightChild, result);
            }
            result.Add(node);

            return result;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            return PreOrderRecursion(this, new List<IAbstractBinaryTree<T>>());
        }
        private List<IAbstractBinaryTree<T>> PreOrderRecursion(IAbstractBinaryTree<T> node, List<IAbstractBinaryTree<T>> result)
        {
            result.Add(node);
            if (node.LeftChild != null)
            {
                PreOrderRecursion(node.LeftChild, result);
            }

            if (node.RightChild != null)
            {
                PreOrderRecursion(node.RightChild, result);
            }

            return result;
        }
        public void ForEachInOrder(Action<T> action)
        {
            if (LeftChild != null)
            {
                LeftChild.ForEachInOrder(action);
            }
            action.Invoke(this.Value);
            if (RightChild != null)
            {
                RightChild.ForEachInOrder(action);
            }
        }

       
    }
}
