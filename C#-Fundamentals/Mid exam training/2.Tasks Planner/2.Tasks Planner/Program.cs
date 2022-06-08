using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Tasks_Planner
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> task = Console.ReadLine()
				.Split(" ")
				.Select(int.Parse)
				.ToList();
			string line = Console.ReadLine();

			while (line != "End")
			{
				string[] tokens = line.Split();
				string command = tokens[0];

				if (command == "Complete")
				{
					int currNum = int.Parse(tokens[1]);
					for (int i = 0; i < task.Count; i++)
					{
						if (currNum == i)
						{
							currNum = 0;
						}
					}
				}
				else if (command == "Change")
				{
					int index = int.Parse(tokens[1]);
					int value = int.Parse(tokens[1]);

					for (int i = 0; i < task.Count; i++)
					{
						if (i == index) task[i] = value;
					}
				}
				else if (command == "Drop")
				{
					for (int i = 0; i < task.Count; i++)
					{
						int indexDrop = task[i];
						if (indexDrop >= 0)
						{
							indexDrop = -1;
						}
					}
				}else if (command == "Count Completed")
				{
					for (int i = 0; i < task.Count; i++)
					{
						int counter = 0;
						int completed = task[i];
						if (completed > 0 && completed <= 5)
						{
							counter++;
						}

					}
				}
			}

			Console.WriteLine();

			for (int i = 0; i < task.Count; i++)
			{
				Console.WriteLine(string.Join(" ",task[i]+" "));
			}
		}
	}
}
