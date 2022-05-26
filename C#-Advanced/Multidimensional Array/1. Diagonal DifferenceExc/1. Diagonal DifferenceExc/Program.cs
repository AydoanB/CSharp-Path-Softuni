using System;
using System.Linq;

namespace _1._Diagonal_DifferenceExc
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

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

            int diagonalDiff = 0;
            int secDiagonal = 0;
            for (int row = 0; row < n; row++)
                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        diagonalDiff += matrix[row, col];
                    }

                    if ((row + col) == (n - 1))
                    {
                        secDiagonal += matrix[row, col];
                    }
                }




            Console.WriteLine(Math.Abs(secDiagonal - diagonalDiff));
           
        }
    }
}
