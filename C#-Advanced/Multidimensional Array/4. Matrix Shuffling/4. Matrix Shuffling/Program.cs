using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] n = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new String[n[0], n[1]];

            for (int row = 0; row < n[0]; row++)
            {
                var colEl = Console.ReadLine()
                    .Split("", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < n[1]; col++)
                {
                    matrix[row, col] = colEl[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var row1 = int.Parse(cmd[1]);
                var col1 = int.Parse(cmd[2]);

                var row2 = int.Parse(cmd[3]);
                var col2 = int.Parse(cmd[4]);



                if (cmd[0] == "swap" &&
                    cmd.Length == 5)
                {
                    int cols = n[1];
                    int rows = n[0];
                    if (row1 >= 0 && row1 <= rows - 1 && col1 >= 0 && col1 <= cols - 1
                        && row2 >= 0 && row2 <= rows - 1 && col2 >= 0 && col2 <= cols - 1)
                    {
                        var temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write($"{matrix[i, j]} ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");

                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");

                }


            }

        }
    }
}

