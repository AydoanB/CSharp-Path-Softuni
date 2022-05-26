using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            bool isFound = false;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                string colElm = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElm[col];
                }

            }
            char symbol = char.Parse(Console.ReadLine());


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        return;
                    }
                    
            }

            if (isFound == false)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
          



        }
    }
}