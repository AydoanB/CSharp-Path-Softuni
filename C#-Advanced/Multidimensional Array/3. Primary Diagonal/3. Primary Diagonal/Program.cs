using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
                
            int[,] matrix = new int[n, n];
            int colSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                int[] colElm = Console.ReadLine()
                    .Split().Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElm[col];
                }

            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                colSum += matrix[row, row];
            }

            Console.WriteLine(colSum);
        }
    }
}
