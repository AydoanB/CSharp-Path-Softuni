using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[n[0], n[1]];
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

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                colSum = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                    colSum += matrix[j, i];


                Console.WriteLine(colSum);
            }


        }
    }
}
