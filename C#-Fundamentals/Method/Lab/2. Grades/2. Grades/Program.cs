using System;

namespace _2._Grades
{
	class Program
	{
		
		static void Main(string[] args)
		{
			double g = double.Parse(Console.ReadLine());
			PrintInWords(g);

			void PrintInWords(double grade)
			{
				if (g >= 2.00 && g <= 2.99) Console.WriteLine("Fail");
				else if (g >= 3.00 && g <= 3.49) Console.WriteLine("Poor");
				else if (g >= 3.50 && g <= 4.49) Console.WriteLine("Good");
				else if (g >= 4.50 && g <= 5.49) Console.WriteLine("Very good");
				else if (g >= 5.50 && g <= 6) Console.WriteLine("Excellent");

				
			}
			
			

		}
	}
}
