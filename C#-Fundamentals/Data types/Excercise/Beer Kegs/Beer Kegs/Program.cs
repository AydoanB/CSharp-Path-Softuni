using System;

namespace Beer_Kegs
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			string maxV = string.Empty;

			double max = int.MinValue;

			for (int i = 0; i < n; i++)
			{
				string m = Console.ReadLine();
				double r = double.Parse(Console.ReadLine());
				int h = int.Parse(Console.ReadLine());

				double v = Math.PI * Math.Pow(r, 2) * h;

				if (v > max)
				{
					max = v;
					maxV=m;
				}
			}
			Console.WriteLine(maxV);

		}
	}
}
