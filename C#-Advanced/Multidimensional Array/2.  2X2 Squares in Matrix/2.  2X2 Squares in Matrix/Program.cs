using System;
using System.Linq;

namespace _2.__2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new String[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] colEl = Console.ReadLine()
                    .Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colEl[col];
                }
            }

            int equalSquareCount = 0;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col]
                        && matrix[row + 1, col + 1] == matrix[row, col]
                        && matrix[row, col + 1] == matrix[row, col])
                    {
                        equalSquareCount++;
                    }
            }

            Console.WriteLine(equalSquareCount);
        }
    }
}
