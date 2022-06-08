using System;

namespace Part_of_ASCII_table
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int p = int.Parse(Console.ReadLine());

			for (int i = n; i <= p; i++)
			{
				string ascii = ((char)i).ToString();
				Console.Write(ascii + " ");
				
			}
		}
	}
}
