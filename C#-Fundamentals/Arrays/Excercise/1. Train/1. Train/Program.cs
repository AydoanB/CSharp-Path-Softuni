using System;
using System.Linq;

namespace _1._Train
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int[] wagon = new int[n];
			int sum = 0;

			for (int i=0;i<n;i++)
			{
				int people = int.Parse(Console.ReadLine());
				wagon[i] = people;
				sum += people;
			}
			Console.WriteLine(string.Join(" ", wagon));
			Console.WriteLine(sum);
		}
	}
}
