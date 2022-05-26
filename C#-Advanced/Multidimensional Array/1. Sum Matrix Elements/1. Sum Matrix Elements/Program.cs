using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrixInput = new int[input[0], input[1]];

            for (int row = 0; row < input[0]; row++)
            {
                int[] colEl = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < input[1]; col++)
                    matrixInput[row, col] = colEl[col];


            }

            int sum = 0;
            for (int row = 0; row < matrixInput.GetLength(0); row++)
            {
                for (int col = 0; col < matrixInput.GetLength(1); col++)
                {
                    sum += matrixInput[row, col];
                }
            }

            Console.WriteLine(matrixInput.GetLength(0));
            Console.WriteLine(matrixInput.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
