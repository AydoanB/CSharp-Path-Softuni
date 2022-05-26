using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jagged = new Double[n][];

            ArrayInput(n, jagged);


            for (int j = 0; j < jagged.Length - 1; j++)
            {
                if (jagged[j].Length == jagged[j + 1].Length)
                {
                    jagged[j] = Multiplier(jagged[j]);
                    jagged[j + 1] = Multiplier(jagged[j + 1]);
                }
                else
                {
                    jagged[j] = Divider(jagged[j]);
                    jagged[j + 1] = Divider(jagged[j + 1]);
                }
            }

            string command = Console.ReadLine();
            while (true)
            {
                string[] cmdSplit = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmdSplit[0] == "Add")
                {
                    int row = int.Parse(cmdSplit[1]);
                    int col = int.Parse(cmdSplit[2]);
                    double value = double.Parse(cmdSplit[3]);
                    if ((row >= 0 && row < jagged.Length) && (col >= 0 && col < jagged[row].Length))
                    {
                        jagged[row][col] = AddOperator(jagged[row][col], value);
                    }
                }
                else if (cmdSplit[0] == "Subtract")
                {
                    int row = int.Parse(cmdSplit[1]);
                    int col = int.Parse(cmdSplit[2]);
                    double value = double.Parse(cmdSplit[3]);
                    if ((row >= 0 && row < jagged.Length) && (col >= 0 && col < jagged[row].Length))
                    {
                        jagged[row][col] = SubOperator(jagged[row][col], value);
                    }
                }
                else if (cmdSplit[0] == "End")
                {
                    foreach (var row in jagged)
                    {
                        Console.Write(string.Join(" ", row));
                        Console.WriteLine();
                    }
                    break;
                }

                command = Console.ReadLine();
            }
        }

        static double AddOperator(double number, double value) =>
            number += value;

        static double SubOperator(double number, double value) =>
            number -= value;

       
        private static void ArrayInput(int n, double[][] arr)
        {
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] numbersAsString = line.Split(' ');
                arr[i] = new Double[numbersAsString.Length];

                for (int j = 0; j < numbersAsString.Length; j++)
                {
                    arr[i][j] = double.Parse(numbersAsString[j]);
                }
            }

        }
        private static void ArrayOutput(double[][] jagged)
        {
            for (int i = 0; i < jagged.Length; i++)
            {

                for (int k = 0; k < jagged[i].Length; k++)
                {
                    System.Console.Write("{0} ", jagged[i][k]);
                }

                System.Console.WriteLine();
            }
        }
        static double[] Multiplier(double[] array) =>
            array = array
                .Select(x => x * 2)
                .ToArray();

        static double[] Divider(double[] array) =>
            array = array
                .Select(x => x / 2)
                .ToArray();
    }
}

