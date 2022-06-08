using System;

namespace _7._Repeat_String
{
	class Program
	{
		static void Main(string[] args)
		{
			string word = Console.ReadLine();
			int repeat = int.Parse(Console.ReadLine());
			var res=RepeatString(word,repeat);

			Console.WriteLine(res);
			
		}
		static string RepeatString(string word, int repeat)
		{
			string result = string.Empty;

			for (int i = 0; i < repeat; i++)
			{
				result += word;
			}
			return result;
		}
	}
}
