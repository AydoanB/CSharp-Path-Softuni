using System;

namespace Converting
{
	class Program
	{
		static void Main(string[] args)
		{
			double meters = double.Parse(Console.ReadLine());
			double kilometer = meters / 1000;

			Console.WriteLine($"{kilometer:f2}");
		
		}
	}
}
