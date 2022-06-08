using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Train
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> train = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToList();
			int maxCapcaity = int.Parse(Console.ReadLine());

			string line = Console.ReadLine();

			while (line != "end")
			{
				string[] tokens = line.Split(' ');

				if (tokens.Length == 2)
				{
					int wagon = int.Parse(tokens[1]);

					train.Add(wagon);

				}
				else
				{
					int currentCapacity = int.Parse(tokens[0]);
					FindWagon(train, maxCapcaity, currentCapacity);
				}
				line = Console.ReadLine();
			}

			Console.WriteLine(string.Join(' ',train));
		}

		static void FindWagon(List<int> train, int maxCap, int currentCap)
		{
			for (int i = 0; i < train.Count; i++)
			{
				int currentWag = train[i];
				if (currentWag + currentCap <= maxCap)
				{
					train[i] += currentCap;
					break;
				}
			}
		}

	}
}

