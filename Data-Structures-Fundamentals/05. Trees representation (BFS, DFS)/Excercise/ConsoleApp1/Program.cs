using System;
using Tree;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeFactory tr = new TreeFactory();
            var input = new string[]
              {
                "8",
                "7 19",
                "7 21",
                "7 14",
                "19 1",
                "19 12",
                "19 31",
                "14 23",
                "14 6"
              };
        }
    }
}