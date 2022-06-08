using System;

namespace _9._Greater_of_Two_Values
{
	class Program
	{
		static void Main(string[] args)
		{
			string type = Console.ReadLine();
			var first = Console.ReadLine();
			var second = Console.ReadLine();

			var result = Value(first, second);

			Console.WriteLine(result);

		}

		static int Value(int first, int second)
		{
			return 0;
		}
		static char Value(char first, char second)
		{
			if (first > second)
			{
				return first;
			}
			return second;
		}
		static string Value(string first, string second)
		{
			if (first.CompareTo(second) > 0)
			{
				return first;
			}
			return second;
		}
	}
}
