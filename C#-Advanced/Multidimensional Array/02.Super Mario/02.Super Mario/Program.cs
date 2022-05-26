using System;
using System.Linq;

namespace _02.Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[,] maze = new char[n, n];
            Input(n, maze);
            int rowDied = 0;
            int colDied = 0;
            while (marioLives > 0)
            {
                string[] arg = Console.ReadLine().Split();
                string move = arg[0];
                int spawnRow = int.Parse(arg[1]);
                int spawnCol = int.Parse(arg[2]);
                maze[spawnRow, spawnCol] = 'B';

                int marioRow = 0;
                int marioCol = 0;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (maze[row, col] == 'M')
                        {
                            marioRow = row;
                            marioCol = col;
                        }

                        //Mario movement
                        if (marioRow > 0 && marioRow < n - 1
                                         && marioCol > 0 && marioRow < n - 1)
                        {
                            Movement(marioRow, marioCol, move, marioLives);
                        }
                        else
                        {
                            marioLives--;
                        }

                        if (maze[marioRow, marioCol] == 'B')
                        {
                            marioLives--;
                            if (marioLives <= 0)
                            {
                                maze[marioRow, marioCol] = 'X';
                            }
                            else
                            {
                                maze[marioRow, marioCol] = '-';
                            }
                        }
                        else if (maze[marioRow, marioCol] == 'P')
                        {
                            maze[marioRow, marioCol] = '-';
                            break;

                        }

                        rowDied = marioRow;
                        colDied = marioCol;
                    }

                }

            }

            if (marioLives <= 0)
            {
                Console.WriteLine($"Mario died at {rowDied};{colDied}.");
            }
            else
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            }
        }

        private static void Input(int n, char[,] maze)
        {
            for (int i = 0; i < n; i++)
            {
                char[] mazeEl = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    maze[i, j] = mazeEl[j];
                }
            }
        }

        private static void Movement(int row, int col, string side, int lives)
        {
            if (side == "W")
            {
                row -= 1;
                lives--;
            }
            else if (side == "S")
            {
                row += 1;
                lives--;
            }
            else if (side == "A")
            {
                col -= 1;
                lives--;
            }
            else if (side == "D")
            {
                col += 1;
                lives--;
            }

        }
    }
}

