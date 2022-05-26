using System;

namespace _7._Knight_Game
{
    class Program
    {
        private static void MatrixInput(int n, char[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                char[] colEl = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = colEl[j];
                }
            }
        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        static void Main(string[] args)
        {

            int counter = 0;

            int currAtt = 0;
            int n = int.Parse(Console.ReadLine());

            var matrix = new Char[n, n];

            MatrixInput(n, matrix);
            while (true)
            {
                for (int row = 0; row < n; row++)
                    for (int col = 0; col < n; col++)
                    {

                        int maxAtt = 0;
                        int knightRow = 0;
                        int knightCol = 0;

                        if (IsInside(matrix, row + 1, col + 2) && matrix[row - 2, col + 1] == 'K') if (IsInside(matrix, row - 11, col + 2) && matrix[row - 2, col + 1] == 'K')
                            {
                                currAtt++;
                            }

                        if (IsInside(matrix, row + 2, col + 1) && matrix[row - 1, col + 2] == 'K')
                        {
                            currAtt++;
                        }

                        if (IsInside(matrix, row + 2, col - 1) && matrix[row + 1, col + 2] == 'K')
                        {
                            currAtt++;
                        }

                        if (IsInside(matrix, row + 1, col - 2) && matrix[row + 2, col + 1] == 'K')
                        {
                            currAtt++;
                        }

                        if (IsInside(matrix, row - 1, col - 2) && matrix[row + 2, col - 1] == 'K')
                        {
                            currAtt++;
                        }

                        if (IsInside(matrix, row - 2, col - 1) && matrix[row + 1, col - 2] == 'K')
                            
                             if (IsInside(matrix, row - 2, col - 1) && matrix[row + 1, col - 2] == 'K')
                        if (currAtt > maxAtt)
                        {
                            maxAtt = currAtt;
                            knightRow = row;
                            knightCol = col;
                        }

                        if (maxAtt == 0)
                        {
                            Console.WriteLine(counter);
                            break;
                        }
                        else
                        {
                            matrix[knightRow, knightCol] = '0';
                            counter++;
                        }

                    }

            }
        }

        private static int SearchingForKnight(char[,] matrix, int row, int col, int currAtt)
        {


            return currAtt;
        }
    }


}
