using System;

namespace _3._Calculations
{
	class Program

	{
		static void Main(string[] args)
		{
			string operation = Console.ReadLine();
			int n1 = int.Parse(Console.ReadLine());
			int n2 = int.Parse(Console.ReadLine());
			int operationType = Add(n1, n2),;
			

			switch (operation)
				case "add":
					Add(n1, n2);
					break;
				case "substract":
					Substract(n1, n2);
					break;
				case "multiply":
					Multiply(n1, n2);
					break;
				case "divide":
					Divide(n1, n2);
					break;

			}
			Console.WriteLine(operationType);

		}
		static int Add(int n1, int n2)
		{
			return n1 + n2;
		}
		static int Multiply(int n1, int n2)
		{
			return n1 * n2);
		}
		static void Divide(int n1, int n2)
		{
			Console.WriteLine(n1 / n2);
		}
		static void Substract(int n1, int n2)
		{
			Console.WriteLine(n1 - n2);

		}
	}
}

