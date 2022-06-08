using System;

namespace _2._Vowels_Count
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();
			PrintVowel(text);
		}
		static void PrintVowel(string text)
		{
			int count = 0;
			foreach (char c in text.ToLower())
			{
				bool isVowel = IsVowel(c);
				if (isVowel)
				{
					count++;
				}
			}
			Console.WriteLine(count);
		}
		static bool IsVowel(char chare)
		{
			bool isVowel = false;
			switch (chare)
			{
				case 'a':
				case 'e':
				case 'o':
				case 'u':
				case 'i':
					isVowel = true;
					break;

			}
			return isVowel;
		}
	}
}
