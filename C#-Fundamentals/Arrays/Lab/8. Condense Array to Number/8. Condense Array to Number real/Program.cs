using System;
using System.Linq;

namespace _8._Condense_Array_to_Number_real
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int final = 1;
			int first = a.Length - 1;

			for(int i=0;i<first;i++)
			{
				int[] mod = new int[a.Length - 1];
				for (int j = 0; j < mod.Length; j++)
					mod[j] = a[j] + a[j + 1];
				a = mod;
				final = mod[0];
			}
			Console.WriteLine(final);
		}
	}
}
