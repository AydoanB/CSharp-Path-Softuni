using System;
using System.Linq;

namespace _7._Max_Sequence_of_Equal_Elements
{
	class Program
	{
		static void Main(string[] args)
		{
			
			
			int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();

			int num=a[0];
			int elcount = 1;
			int bestN = a[0];
			int bestCount = 1;

			for (int i=0;i<a.Length-1;i++)
			{
				int el = a[i];
				int next = a[i + 1];
				if(el==next)
				{
				 	elcount++;
				}
				else
				{
					elcount = 1;
					num = next;
				}
				if(elcount>bestCount)
				{
					bestCount = elcount;
					bestN = num;
				}
			}
			for (int i = 0; i < bestCount; i++)
			{
				Console.Write(bestN + " ");
			}
		}
	}
}
