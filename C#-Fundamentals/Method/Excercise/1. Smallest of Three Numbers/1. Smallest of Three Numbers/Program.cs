using System;

namespace _1._Smallest_of_Three_Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			int num1 = int.Parse(Console.ReadLine());
			int num2 = int.Parse(Console.ReadLine());
			int num3 = int.Parse(Console.ReadLine());

			PrintSmallestofThreeNum(num1, num2, num3);
		}
		static void PrintSmallestofThreeNum(int n1,int n2,int n3)
		{
			int small = 0;
			if (n1 < n2 && n1<n3) small = n1;
			else if (n2 < n3) small = n2;
			else small = n3;
			Console.WriteLine(small);
		}
	}
}
