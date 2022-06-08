using System;

namespace _4._Printing_Triangle
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			PrintingTriangle(n);

			void PrintingTriangle(int value)
			{
				for (int i = 1; i < value + 1; i++)
				{
					for (int y = 1; y <= i; y++)
					{
						Console.Write(y + " ");
					}
					Console.WriteLine();
				}
				for (int i = value-1; i >= 1; i--)
				{
					for (int y = 1; y <= i; y++)
					{
						Console.Write(y + " ");
					}
					Console.WriteLine();
				}



			}
		}
	}
}
