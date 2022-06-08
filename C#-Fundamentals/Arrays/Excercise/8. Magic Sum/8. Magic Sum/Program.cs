using System;
using System.Linq;

namespace _8._Magic_Sum
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] num = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int sum = int.Parse(Console.ReadLine());

			for (int i = 0; i < num.Length; i++)
			{
				int curr = num[i];
				for (int j = i + 1; j < num.Length; j++)
				{
					if (curr + num[j] == sum)
					{
						Console.WriteLine(curr + " " + num[j]);
					}
				}
			}
		}
	}
}
