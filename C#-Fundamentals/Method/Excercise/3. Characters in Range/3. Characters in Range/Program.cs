using System;

namespace _3._Characters_in_Range
{
	class Program
	{
		static void Main(string[] args)
		{
			char char1 =char.Parse(Console.ReadLine());
			char char2 =char.Parse(Console.ReadLine());

			InRange(char1, char2);
		}
		static void InRange(char char1,char char2)
		{
			int start = Math.Min(char1, char2);
			int end = Math.Max(char1, char2);
			for(int i=++start;i<end;i++)
			{
				Console.Write((char) i+ " ");
			}
			Console.WriteLine();

			
		}
	}
}
