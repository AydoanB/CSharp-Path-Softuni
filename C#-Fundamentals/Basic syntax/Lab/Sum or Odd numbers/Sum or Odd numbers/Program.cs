using System;

namespace Sum_or_Odd_numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());
			var sum = 0; 

			for(int i=1;i<=n;i++)
			{
				Console.WriteLine("{0}", 2 * i - 1);
				sum += 2 * i - 1;
			}
			Console.WriteLine("Sum: {0}",sum);
		}
	}
}
