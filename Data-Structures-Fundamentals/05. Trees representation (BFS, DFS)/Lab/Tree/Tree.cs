using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;
        private bool IsRootRemoved = false;

        public Tree(T value)
        {
            Value = value;
            this.Parent = null;
            _children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                _children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subtree = queue.Dequeue();

                result.Add(subtree.Value);

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            if (IsRootRemoved)
            {
                return Array.Empty<T>();
            }
            return result;
        }

        private Tree<T> FindBfs(T key)
        {
            var result = OrderBfs();
            var el = result.FirstOrDefault(x => x.Equals(key));
            if (el.Equals(_children[0].Parent.Value))
            {
                return _children[0].Parent;
            }

            
            return _children.Find(x=>x.Value.Equals(el));
        }

        public ICollection<T> OrderDfs()
        {
            var order = new List<T>();
            this.Dfs(this, order);
            if (IsRootRemoved)
            {
                return Array.Empty<T>();
            }
            return order;
        }

        private void Dfs(Tree<T> tree, List<T> order)
        {
            foreach (var child in tree.Children)
            {
                this.Dfs(child, order);
            }
            order.Add(tree.Value);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var node = FindBfs(parentKey);
            if (node == null) throw new ArgumentNullException();
           
            node._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {

            var node = FindBfs(nodeKey);
            if (node == null) throw new ArgumentNullException();

            if (node.Parent == null)
            {
                node._children.Clear();
                IsRootRemoved = true;
            }

            else
            {
                var nodeParent = node.Parent;

                nodeParent._children.RemoveAll(x => x.Value.Equals(nodeKey));
            }


            //var searched = FindBfs(nodeKey);

            //foreach (var child in searched._children)
            //{
            //    child.Parent = null;
            //}
            //searched._children.Clear();
            //var searchedParent = searched.Parent;

            //if (searchedParent != null)
            //{
            //    searchedParent._children.Remove(searched);
            //}

            //searched.Value = default(T);
        }
        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = _children.FirstOrDefault(x => x.Value.Equals(firstKey));
            if (firstNode == null) throw new ArgumentNullException();
            var firstParent = firstNode.Parent;
            var secondNode = _children.FirstOrDefault(x => x.Value.Equals(secondKey));
            if (secondNode == null) throw new ArgumentNullException();
            var secondParent = secondNode.Parent;

            firstNode.Parent = secondParent;
            secondNode.Parent = firstParent;

            int indexOfFirst = firstParent._children.IndexOf(firstNode);
            int indexOfSecond = secondParent._children.IndexOf(secondNode);

            firstParent._children[indexOfFirst] = secondNode;
            secondParent._children[indexOfSecond] = firstNode;

        }
    }
}
