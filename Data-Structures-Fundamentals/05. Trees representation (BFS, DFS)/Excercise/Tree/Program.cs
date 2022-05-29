using System;

namespace Tree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tree<int> Tree = new Tree<int>(7, new Tree<int>(12, new Tree<int>(15),
                new Tree<int>(25)));

            Console.WriteLine(Tree.BFS());
        }
    }
}