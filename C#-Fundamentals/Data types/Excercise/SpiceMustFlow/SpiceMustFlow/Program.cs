using System;

namespace SpiceMustFlow
{
	class Program
	{
		static void Main(string[] args)
		{
			int starting = int.Parse(Console.ReadLine());

			int amount = 0;
			int day = 0;
			while (starting >= 100)
			{
				amount += starting;
				starting -= 10;
				day++;

				if (amount - 26 < 0)
				{
					amount = 0;
				}
				else amount -= 26;
			}
			if (amount - 26 < 0)
			{
				amount = 0;
			}
			else amount -= 26;
			Console.WriteLine(day);
			Console.WriteLine(amount);
		}
	}
}
