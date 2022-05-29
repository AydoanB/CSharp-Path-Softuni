using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var lines in input)
            {
                var line = lines.Split(' ').Select(int.Parse).ToArray();
                if (!nodesBykeys.ContainsKey(line[0]))
                {
                    var node = CreateNodeByKey(line[0]);
                    nodesBykeys.Add(line[0], node);
                }

                if (!nodesBykeys.ContainsKey(line[1]))
                {
                    var node = CreateNodeByKey(line[1]);
                    nodesBykeys.Add(line[1], node);
                }
                AddEdge(line[0], line[1]);
            }

            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            return new Tree<int>(key);
        }

        public void AddEdge(int parent, int child)
        {
            nodesBykeys[parent].AddChild(nodesBykeys[child]);
            nodesBykeys[child].AddParent(nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            var node = nodesBykeys.FirstOrDefault().Value;
            while (node.Parent != null)
            {
                node = node.Parent;
            }

            return node;
        }
    }
}
