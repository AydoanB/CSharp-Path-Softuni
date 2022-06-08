using System;

namespace _8._Math_Power
{
	class Program
	{
		static void Main(string[] args)
		{
			double a = double.Parse(Console.ReadLine());
			double b = double.Parse(Console.ReadLine());
			double Math = GetMath(a, b);
			
		}
		static int GetMath(double a,double b)
		{
			Console.WriteLine(Math.Pow(a, b));
			return 0;
		}
	}
}
