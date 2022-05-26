using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ");
                
            var songQueue = new Queue<string>(input);
            

            

            while (songQueue.Any())
            {
               
                string command = Console.ReadLine();

               
                if (command == "Play")
                {
                    songQueue.Dequeue();
                }
                else if (command.StartsWith("Add"))
                {
                    string song = command.Substring(4);
                    if (!songQueue.Contains(song))
                    {
                        songQueue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ",songQueue));
                }

               
                
            }
            Console.WriteLine("No more songs!");
        }
    }
}
