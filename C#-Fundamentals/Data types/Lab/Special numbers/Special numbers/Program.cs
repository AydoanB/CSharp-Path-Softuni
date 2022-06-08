using System;

namespace Special_numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int sum = 0;
			int digits = 0;



			for (int i = 1; i <= n; i++)
			{
				sum += i % 10;

				while (i != 0)
				{
					digits = i / 10;
				}
				if (sum == 5 || sum == 7 || sum == 11)
				{
					Console.WriteLine($"{i} -> True");
				}
				else Console.WriteLine($"{i} -> False");
			}
			
		}
	}
}
