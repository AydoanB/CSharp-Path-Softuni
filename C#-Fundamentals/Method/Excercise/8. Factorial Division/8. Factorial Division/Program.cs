using System;

namespace _8._Factorial_Division
{
	class Program
	{
		static void Main(string[] args)
		{
			double n1 = int.Parse(Console.ReadLine());
			double n2 = int.Parse(Console.ReadLine());
			Factoriel(n1,n2);
		}

		static void Factoriel(double num1, double num2)
		{
			double factoriel = 1;
			for (int i = 1; i <= num1; i++)
			{
				factoriel *= i;
			}

			double factorielTwo = 1;
			for (int i = 1; i <= num2; i++)
			{
				factorielTwo *= i;
			}

			double result = factoriel / factorielTwo;
			Console.WriteLine($"{result:f2}");
			
		}
	}
}
