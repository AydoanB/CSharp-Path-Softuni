using System;

namespace _5._Add_and_Subtract
{
	class Program
	{
		static void Main(string[] args)
		{
			int n1 = int.Parse(Console.ReadLine());
			int n2 = int.Parse(Console.ReadLine());
			int n3 = int.Parse(Console.ReadLine());

			int sumres=Sum(n1, n2);
			int resylt = Substract(sumres, n3);
			Console.WriteLine(resylt);
		}
		static int Sum(int num1,int num2)
		{
			int res = num1 + num2;
			return res;
		}
		static int Substract(int num1, int num2)
		{
			int res = num1 - num2;
			return res;
		}
	}
}
