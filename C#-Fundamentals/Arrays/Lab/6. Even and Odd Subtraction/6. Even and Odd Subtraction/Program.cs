using System;
using System.Linq;

namespace _6._Even_and_Odd_Subtraction
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int sumOdd = 0;
			int sumEven = 0;

			for (int i = 0; i < num.Length; i++)
			{
				int current = num[i];

				if (current % 2 == 0) sumEven += current;
				else sumOdd += current;
			}
			int diff = sumEven - sumOdd;
			Console.WriteLine(diff);
		}
	}
}
