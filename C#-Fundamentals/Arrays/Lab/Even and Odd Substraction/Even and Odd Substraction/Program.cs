using System;
using System.Linq;

namespace Sum_even_numbers
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

					if (current % 2 == 0) sumOdd += current;
					else sumEven += current;
				}
			int difference = sumEven - sumOdd;
				Console.WriteLine(difference);
			}
		}
	}


