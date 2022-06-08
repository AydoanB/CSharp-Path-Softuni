using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _2._Gauss__Trick
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> num = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			int originalLenght = num.Count;

			for (int i = 0; i < originalLenght / 2; i++)
			{
				num[i] += num[num.Count - 1];
				num.RemoveAt(num.Count - 1);
			}

			Console.WriteLine(string.Join(" ", num));


		}
	}
}
