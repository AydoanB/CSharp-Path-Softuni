using System;
using System.Linq;

namespace Sum_even_numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int sum = 0;

			for(int i=0;i<num.Length;i++)
			{
				int current = num[i];

				if (current % 2 == 0) sum += current;
			}
			Console.WriteLine(sum);
		}
	}
}
