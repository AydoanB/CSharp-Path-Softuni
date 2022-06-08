using System;

namespace _1.Black_Flag
{
	class Program
	{
		static void Main(string[] args)
		{
			int days = int.Parse(Console.ReadLine());
			double dailyPlunder = int.Parse(Console.ReadLine());
			double expectedPlunder = double.Parse(Console.ReadLine());
			double winLose = 0.0;

			

			for (int i = 1; i <= days; i++)
			{
				winLose += dailyPlunder;
				if (i % 3 == 0)
				{
					winLose += dailyPlunder / 2.0;
				}

				if (i % 5 == 0)
				{
					winLose -= winLose * 0.3;
				}
			}
			double perc = (winLose / expectedPlunder) * 100;
			if (winLose >= expectedPlunder)
			{
				Console.WriteLine($"Ahoy! {winLose:f2} plunder gained.");
			}
			
			else
			{
				Console.WriteLine($"Collected only { perc:f2}% of the plunder.");
			}

		}
	}
}
