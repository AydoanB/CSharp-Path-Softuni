using System;

namespace ElSumOhters
{
	class Program
	{
		static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());
			var sum = 0;
			var num = 0;
			int max = int.MinValue;
			for (int i = 1; i <= n; i++)
			{
				num = int.Parse(Console.ReadLine());
				if (num > max)
				{
					max = num;
				}
				sum += num;
			}
			sum = sum - max;
			if (sum == max)
				Console.WriteLine("Yes sum = " + sum);
			else
				Console.WriteLine("No Diff = " + Math.Abs(sum - max));
		}
	}
}
