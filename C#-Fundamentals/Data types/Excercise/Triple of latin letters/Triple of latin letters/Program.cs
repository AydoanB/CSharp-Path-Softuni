using System;

namespace Triple_of_latin_letters
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					for (int q = 0; q < n; q++)
					{
						Console.WriteLine($"{(char)(i + 'a')}{(char)(j + 'a')}{(char)(q + 'a')}");
					}
				}
			}
		}
	}
}
