using System;

namespace Ages
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			if (0 <= n && 2 >= n) Console.WriteLine("baby");
			else if (3 <= n && 13 >= n) Console.WriteLine("child");
			else if (14 <= n && 19 >= n) Console.WriteLine("teenager");
			else if (20 <= n && 65 >= n) Console.WriteLine("adult");
			else if (66 <= n) Console.WriteLine("elder");
		}
	}
}
