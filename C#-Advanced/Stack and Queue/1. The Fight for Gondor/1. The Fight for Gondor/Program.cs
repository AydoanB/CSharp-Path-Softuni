using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> plateQueue = new Queue<int>(Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Stack<int> warriorStack = new Stack<int>();

            for (int i = 1; i <= n; i++)
            {
                Stack<int> newWaveOrcs = new Stack<int>(Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    int additionOn3rdLine = int.Parse(Console.ReadLine());
                    plateQueue.Enqueue(additionOn3rdLine);
                }
                while (plateQueue.Count != 0 && newWaveOrcs.Count != 0)
                {


                    //this works
                    if (newWaveOrcs.Peek() > plateQueue.Peek())
                    {
                        newWaveOrcs.Push(newWaveOrcs.Pop() - plateQueue.Dequeue());
                    }
                    else if (plateQueue.Peek() > newWaveOrcs.Peek())
                    {
                        Queue<int> updatedPlatesOfTheAragornsDefence = new Queue<int>();

                        updatedPlatesOfTheAragornsDefence.Enqueue(plateQueue.Dequeue() - newWaveOrcs.Pop());
                        for (int j = 0; j < plateQueue.Count; j++)
                        {
                            updatedPlatesOfTheAragornsDefence.Enqueue(plateQueue.ElementAt(j));
                        }

                        plateQueue = updatedPlatesOfTheAragornsDefence;
                    }
                    else
                    {
                        newWaveOrcs.Pop();
                        plateQueue.Dequeue();
                    }
                    if (plateQueue.Count == 0)
                    {
                        warriorStack = newWaveOrcs;
                        break;
                    }
                }


            }
            if (warriorStack.Any())
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {0}", string.Join(", ", warriorStack));
            }
            else
            {

                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {0}", string.Join(", ", plateQueue));
            }


        }
    }
}
