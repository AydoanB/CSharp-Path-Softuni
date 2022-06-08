using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Change_List
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> num = Console.ReadLine()
				.Split(" ")
				.Select(int.Parse)
				.ToList();
			string line = Console.ReadLine();

			while (line != "end")
			{
				string[] tokens = line.Split(' ');
				string cmd = tokens[0];
				int element = int.Parse(tokens[1]);

				if (cmd == "Delete")
				{
					

					num.RemoveAll(x => x == element);
				}
				else if (cmd == "Insert")
				{
					int insertedEl = int.Parse(tokens[2]);
					num.Insert(insertedEl,element);
				}
				line = Console.ReadLine();
			}

			Console.WriteLine(string.Join(" ",num));
		}
	}
}
