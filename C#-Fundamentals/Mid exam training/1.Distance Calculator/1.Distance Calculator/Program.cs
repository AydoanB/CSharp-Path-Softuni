using System;

namespace _1.Distance_Calculator
{
	class Program
	{
		static void Main(string[] args)
		{
			double step = double.Parse(Console.ReadLine());
			double lenghtOf1Step = double.Parse(Console.ReadLine());
			int distanceToTravel = int.Parse(Console.ReadLine());
			double result = 0.0;


			for (int i = 1; i <= step; i++)
			{
				if (i % 5 == 0)
				{
					double shortStep = lenghtOf1Step*0.70;
					result += shortStep;
				}
				else
				{
					result += lenghtOf1Step;
				}
			}
			result /= 100;
			double distanceInCM = result / distanceToTravel * 100;
			
			Console.WriteLine($"You travelled {distanceInCM:f2}% of the distance!");
		}
	}
}
