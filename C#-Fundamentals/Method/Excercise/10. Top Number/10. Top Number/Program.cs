using System;

namespace _10._Top_Number
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			for (int i = 1; i <= n; i++)
			{
				bool isTopNUmber = IsTopNum(i);
				if (isTopNUmber)
				{
					Console.WriteLine(i);
				}
			}
		}

		static bool IsTopNum(int num)
		{
			bool isTopNum = false;
			bool isOddDigit = false;
			int temp = num;
			int sum = 0;
			while (temp > 0)
			{
				int digit = temp % 10;
				sum += digit;
				temp /= 10;

				if (digit % 2 != 0)
				{
					isOddDigit = true;
				}
			}

			if (sum % 8 == 0)
			{
				isTopNum = true;
			}

			return isTopNum && isOddDigit;


		}
	}
}
