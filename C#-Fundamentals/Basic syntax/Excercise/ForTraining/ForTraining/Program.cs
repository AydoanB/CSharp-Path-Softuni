using System;

namespace ForTraining
{
	class Program
	{
		static void Main(string[] args)
		{
			for(int n=1;n<=1000;n++)
			{
				if (n % 10 == 7) Console.WriteLine(n);
			}
		}
	}
}
