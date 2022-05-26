using System;
using System.Linq;
using System.Numerics;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] mineField = new String[n, n];

            MatrixInput(n, mineField);

            while (true)
            {
                int minerRow = 0;
                int minerCol = 0;
                string[] cmdArgs = Console.ReadLine().Split();

                for (int row = 0; row < n; row++)

                {
                    for (int col = 0; col < n; col++)
                    {
                        if (mineField[row, col] == "s")
                        {
                            minerRow = row;
                            minerCol = col;
                        }

                    }
                }




            }

        }

        private static void MatrixInput(int n, string[,] mineField)
        {
            for (int i = 0; i < n; i++)
            {
                string[] colEl = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    mineField[i, j] = colEl[j];
                }

            }
        }

        private static bool IsValid(int row, int col,string [,] mineField)
        {

        }
    }
}