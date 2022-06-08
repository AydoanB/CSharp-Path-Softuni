using System;

namespace _1.Gift_Box_Coverage
{
	class Program
	{
		static void Main(string[] args)
		{
			double sizeOfSide = double.Parse(Console.ReadLine());
			int numPaper = int.Parse(Console.ReadLine());
			double areaOfSheet = double.Parse(Console.ReadLine());
			double paper = 0;
			double area = 0;

			for (int i = 1; i <= numPaper; i++)
			{
				sizeOfSide*=sizeOfSide*6;
				if (i % 3 == 0)
				{
					sizeOfSide += sizeOfSide * 0.75;
				}

				area = sizeOfSide - numPaper;

				double totalareaOfSheet = area * areaOfSheet + sizeOfSide*(areaOfSheet*0.75);
			}

			
		}
	}
}
