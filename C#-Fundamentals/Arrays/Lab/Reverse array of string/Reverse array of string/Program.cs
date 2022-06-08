using System;
using System.Linq;

namespace Reverse_array_of_string
{
	class Program
	{
		static void Main(string[] args)
		{
			var item = Console.ReadLine().Split(' ').ToArray();
			
			for(int i=0;i<item.Length;i++)
			{
				var oldEl = item[i];
				item[i] = item[item.Length - 1 - i];
				item[item.Length - 1 - i] = oldEl;
			}
			for (int i = item.Length-1;i>=0; i--)
			{
				Console.Write(item[i]+" ");
			}
		}
	}
}
