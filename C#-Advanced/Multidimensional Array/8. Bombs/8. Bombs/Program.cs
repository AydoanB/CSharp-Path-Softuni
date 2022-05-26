using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sum = 0;
            int aliveCells = 0;
            for (int i = 0; i < n; i++)
            {
                int[] colEl = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = colEl[j];
                }
            }

            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var rowCol in coordinates)
            {
                int[] currentBombCoordinates = rowCol
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int currentBombRow = currentBombCoordinates[0];
                int currentBombCol = currentBombCoordinates[1];
                int currentBomb = matrix[currentBombRow, currentBombCol];



                for (int i = currentBombRow - 1; i <= currentBombRow + 1; i++)
                for (int j = currentBombCol - 1; j <= currentBombCol + 1; j++)
                {
                    if (i >= 0 && i < n && j >= 0 && j < n)
                    {
                        if (matrix[i, j] <= 0 || currentBomb < 0)
                        {
                            continue;
                        }

                        matrix[i, j] -= currentBomb;
                    }

                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        aliveCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(string.Format("{0} ", matrix[row, col]));
                }

                Console.WriteLine();
            }


        }
    }
}
