using System;
using System.Linq;

namespace _2._Common_Elements
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] a1 = Console.ReadLine().Split().ToArray();
			string[] a2 = Console.ReadLine().Split().ToArray();

			foreach(string el2 in a2)
			{
				for(int i=0;i<a1.Length;i++)
				{
					string el1 = a1[i];
					if(el2==el1)
					{
						Console.Write(el1 + " ");
						break;
					}
				}
			}
		}
	}
}
