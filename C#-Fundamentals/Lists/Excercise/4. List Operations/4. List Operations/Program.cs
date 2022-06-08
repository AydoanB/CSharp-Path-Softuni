using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _4._List_Operations
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> num= Console.ReadLine()
				.Split(' ')
				.Select(int.Parse)
				.ToList();

			string line = Console.ReadLine();

			while (line != "End")
			{
				string[] tokens = line.Split(' ');
				string command = tokens[0];
				
				

				if (command == "Add")
				{
					int currNum = int.Parse(tokens[1]);
					num.Add(currNum);
				}
				else if (command=="Insert")
				{
					int currNum = int.Parse(tokens[1]);
					int index = int.Parse(tokens[2]);

					if (index >= 0 && index < num.Count)
					{
						num.Insert(index,currNum);
					}
					else
					{
						Console.WriteLine("Invalid index");
					}
					
				}
				else if (command == "Remove")
				{
					int index = int.Parse(tokens[1]);

					if (index >= 0 && index < num.Count)
					{
						num.RemoveAt(index);
					}
					else Console.WriteLine("Invalid index");
				}

				else if (line.Contains("Shift left"))
				{
					int count = int.Parse(tokens[2]);

					for (int i = 0; i < count; i++)
					{
						int currNum = num[0];
						num.RemoveAt(0);
						num.Add(currNum);
					}
				}
				else if (line.Contains("Shift right"))
				{
					int count = int.Parse(tokens[2]);

					for (int i = 0; i < count; i++)
					{
						int currNum = num[num.Count - 1];
						num.RemoveAt(num.Count-1);
						num.Insert(0,currNum);
					}
				}
				

				line = Console.ReadLine();
			}

			Console.WriteLine(string.Join(' ',num));
		}

		static void Add(List<int> num, int currNum)
		{
			
			num.Add(currNum);
		}
	}
}
