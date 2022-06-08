using System;
using System.Linq;

namespace Rounding_Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			double[] n = Console.ReadLine().Split().Select(double.Parse).ToArray();

			int[] a = new int[n.Length];

			for (int i = 0; i < n.Length; i++)
			{
				a[i] = (int)Math.Round(n[i], MidpointRounding.AwayFromZero);
			}
			for (int i = 0; i < n.Length; i++)
			{
				Console.WriteLine($"{n[i]} => {a[i]}");
			}

		}
	}
}
