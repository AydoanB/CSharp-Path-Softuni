using System;

namespace Poke_Mon
{
	class Program
	{
		static void Main(string[] args)
		{
			int power = int.Parse(Console.ReadLine());
			int dist = int.Parse(Console.ReadLine());
			int exhaustion = int.Parse(Console.ReadLine());

			double temp = power * 0.5;
			int count = 0;

			while (power >= dist)
			{
				count++;
				power -= dist;

				if (power == temp && exhaustion != 0)
				{
					power /= exhaustion;
				}


			}
			Console.WriteLine(power);
			Console.WriteLine(count);
		}
	}
}
