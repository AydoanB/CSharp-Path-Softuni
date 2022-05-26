using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            _children = new List<Tree<T>>();
            foreach (var child in children)
            {
                child.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }
        public int Longest { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return Stringify().Trim();
        }

        private string Stringify(int indentation = 0)
        {
            string result = new string(' ', +indentation) + this.Key + "\r\n";

            foreach (var child in this.Children)
            {
                result += child.Stringify(indentation + 2);
            }

            return result;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var result = GetLongestTree();

            return result.Last();
        }

        private List<Tree<T>> GetLongestTree()
        {
            var leafNodes = GetLeafNodes();
            var path = new List<List<Tree<T>>>();
            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                var currentNodes = new List<Tree<T>>();
                while (node != null)
                {
                    currentNodes.Add(node);
                    node = node.Parent;
                }

                currentNodes.Reverse();
                path.Add(currentNodes);
            }
            return path.OrderByDescending(x => x.Count).First();
        }
        public List<T> GetLongestPath()
        {
            var result = GetLongestTree();

            return result.Select(x => x.Key).ToList();

        }

        public List<T> GetLeafKeys()
        {
            var result = GetLeafNodes();

            return result.Select(x => x.Key).ToList();
        }

        private List<Tree<T>> GetLeafNodes()
        {
            List<Tree<T>> result = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Any())
            {
                var el = queue.Dequeue();


                foreach (var child in el.Children)
                {
                    if (child.Children.Count == 0)
                    {
                        result.Add(child);
                    }
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> result = new List<T>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Any())
            {
                var el = queue.Dequeue();


                foreach (var child in el.Children)
                {
                    if (child.Children.Count != 0 && child.Parent != null)
                    {
                        result.Add(child.Key);
                    }
                    queue.Enqueue(child);
                }
            }

            return new List<T>(result.OrderBy(x => x));
        }



        private void Dfs(Tree<T> tree, List<T> order)
        {
            foreach (var child in tree.Children)
            {
                this.Dfs(child, order);
            }
            order.Add(tree.Key);
        }
        public List<T> OrderDfs()
        {
            var order = new List<T>();
            this.Dfs(this, order);

            return order;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var LeafNodes = GetLeafNodes();
            List<List<T>> paths = new List<List<T>>();
            foreach (var leaf in LeafNodes)
            {
                var node = leaf;
                var currentSum = 0;
                var currentNodes = new List<T>();

                while (node != null)
                {
                    currentNodes.Add(node.Key);
                    currentSum += Convert.ToInt32(node.Key);
                    node = node.Parent;
                }

                if (currentSum == sum)
                {
                    currentNodes.Reverse();
                    paths.Add(currentNodes);
                }
            }

            return paths;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var leafs = GetLeafNodes();
            var subtrees = new List<List<Tree<T>>>();
            foreach (var leaf in leafs)
            {
                var node = leaf;
                var parent = node.Parent.Children;
                var currentNodes = new List<Tree<T>> {node.Parent};
                var currentSum = Convert.ToInt32(node.Parent.Key);
                foreach (var children in parent)
                {
                    currentNodes.Add(children);
                    currentSum += Convert.ToInt32(children.Key);
                    if (currentSum == sum)
                    {
                        subtrees.Add(currentNodes);
                    }

                }

               
            }

            
        }

        public List<T> BFS()
        {
            List<T> result = new List<T>();
            Tree<T> root = Parent;

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Any())
            {
                var el = queue.Dequeue();
                result.Add(el.Key);

                foreach (var child in el.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
    }
}
