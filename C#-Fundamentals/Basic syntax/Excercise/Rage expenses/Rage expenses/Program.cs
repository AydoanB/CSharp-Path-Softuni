using System;

namespace Rage_expenses
{
	class Program
	{
		static void Main(string[] args)
		{
			int lostGames = int.Parse(Console.ReadLine());
			double headset = double.Parse(Console.ReadLine());
			double mouse = double.Parse(Console.ReadLine());
			double keyboard = double.Parse(Console.ReadLine());
			double display = double.Parse(Console.ReadLine());

			double expenses = 0;

			for (int i = 1; i <= lostGames; i++)
			{
				if (i % 2 == 0)
				{
					expenses += headset;
				}
				if (i % 3 == 0)
				{
					expenses += mouse;
				}
				if (i % 6 == 0)
				{
					expenses += keyboard;
				}
				if (i % 12 == 0)
				{
					expenses += display;
				}

			}
			Console.WriteLine($"Rage expenses: {expenses:f2} lv.");

		}
	}
}
