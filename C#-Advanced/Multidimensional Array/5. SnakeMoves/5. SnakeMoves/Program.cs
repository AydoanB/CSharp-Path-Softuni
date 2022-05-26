using System;
using System.Linq;
using System.Numerics;

namespace _5._SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string input = Console.ReadLine();

            var snake = new Char[n[0], n[1]];

            int counter = 0;
            bool leftToRight = true;
            for (int row = 0; row < n[0]; row++)
            {

                if (leftToRight)
                {
                    for (int col = 0; col < n[1]; col++)
                    {
                        snake[row, col] = input[counter++];

                        if (counter == input.Length)
                        {
                            counter = 0;
                        }
                    }
                    leftToRight = false;

                }

                else
                {

                    for (int col = n[1] - 1; col >= 0; col--)
                    {
                        snake[row, col] = input[counter++];

                        if (counter == input.Length)
                        {
                            counter = 0;
                        }
                    }

                    leftToRight = true;
                }

            }

            for (int i = 0; i < snake.GetLength(0); i++)
            {
                for (int j = 0; j < snake.GetLength(1); j++)
                {
                    Console.Write(snake[i, j]);
                }
                Console.WriteLine();
            }

        }


    }
}
