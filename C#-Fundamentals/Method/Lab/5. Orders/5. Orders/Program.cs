using System;

namespace _5._Orders
{
	class Program
	{
		static void Main(string[] args)
		{
			string order = Console.ReadLine();
			int quantity = int.Parse(Console.ReadLine());
			double price = 0;

			void ordertype()
			{
				if (order == "coffee") price = 1.50;
				else if (order == "water") price = 1.00;
				else if (order == "coke") price = 1.40;
				else if (order == "snacks") price = 2.00;
				Console.WriteLine($"{price * quantity:f2}");
			}
			ordertype();

		}
	}
}
