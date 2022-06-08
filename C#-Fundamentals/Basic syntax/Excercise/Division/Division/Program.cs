using System;

namespace Division
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());


			if (n % 10 == 0) Console.WriteLine($"The number is divisible by 10", n); 
			else if (n % 7 == 0) Console.WriteLine($"The number is divisible by 7", n);
			else if (n % 6 == 0) Console.WriteLine($"The number is divisible by 6", n);
			else if (n % 3 == 0) Console.WriteLine($"The number is divisible by 3", n);
			else if (n % 2 == 0) Console.WriteLine($"The number is divisible by 2", n);
			else Console.WriteLine("Not divisible");

		}
	}
}
