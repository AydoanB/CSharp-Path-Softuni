using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Number_Array
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> num = Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToList();
			string line = Console.ReadLine();
			int sumPositive = 0;
			int sumNegative = 0;
			int sumAll = 0;

			while (line != "End")
			{
				string[] tokens = line.Split();
				string command = tokens[0];

				if (command == "Switch")
				{
					int currNum = int.Parse(tokens[1]);
					for (int i = 0; i < num.Count; i++)
					{
						if (currNum == i)
						{
							int swNum = num[i];
							swNum *= -1;
							num[i] = swNum;
						}
					}
				}
				else if (command == "Change")
				{
					int index = int.Parse(tokens[1]);
					int value = int.Parse(tokens[1]);

					for (int i = 0; i < num.Count; i++)
					{
						if (i == index) num[i] = value;
					}
				}
				else if (command == "Sum negative")
				{

					for (int i = 0; i < num.Count; i++)
					{
						if (num[i] < 0)
						{
							sumNegative += num[i];
						}
					}
				}
				else if (command == "Sum positive")
				{

					for (int i = 0; i < num.Count; i++)
					{
						if (num[i] > -1)
						{
							sumPositive += num[i];
						}
					}
				}
				else if (command == "All")
				{

					for (int i = 0; i < num.Count; i++)
					{

						sumAll += num[i];

					}
				}
			}

			if (sumNegative < 0)
			{
				Console.WriteLine(sumNegative);
			}
			else if (sumPositive > 0)
			{
				Console.WriteLine(sumPositive);
			}
			else if (sumAll != 0)
			{
				Console.WriteLine(sumAll);
			}

			for (int i = 0; i < num.Count; i++)
			{
				if (num[i] >= 0)
				{
					Console.Write(string.Join(" ", num[i] + " "));
				}
			}
		}
	}
}