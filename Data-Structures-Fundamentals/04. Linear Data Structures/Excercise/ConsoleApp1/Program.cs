using Problem02.DoublyLinkedList;
using System;
using System.Linq;
using Problem03.ReversedList;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ReversedList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(string.Join(" ", list));

            list.Insert(2,1001);
            Console.WriteLine(list.IndexOf(1001));
            Console.WriteLine(string.Join(" ", list));

            Console.WriteLine(list[0]);

            
        }
    }
}
