﻿using System;
namespace trade_commisions
{
	class Program
	{
		static void Main(string[] args)
		{
			var town = Console.ReadLine().ToLower();
			var sales = double.Parse(Console.ReadLine());
			var commissions = -1.0;

			if (sales < 0)
			{
				Console.WriteLine("error");
				return;
			}
			if (town != "sofia" && town != "varna" && town != "plovdiv")
			{
				Console.WriteLine("error");
			}


			if (town == "sofia")
			{
				if (0 <= sales && sales <= 500) commissions = 0.05;
				else if (500 <= sales && sales <= 1000) commissions = 0.07;
				else if (1000 <= sales && sales <= 10000) commissions = 0.08;
				else if (sales >= 10000) commissions = 0.12;
			}
			if (town == "varna")
			{
				if (0 <= sales && sales <= 500) commissions = 0.045;
				else if (500 <= sales && sales <= 1000) commissions = 0.075;
				else if (1000 <= sales && sales <= 10000) commissions = 0.10;
				else if (sales >= 10000) commissions = 0.13;
			}
			if (town == "plovdiv")
			{
				if (0 <= sales && sales <= 500) commissions = 0.055;
				else if (500 <= sales && sales <= 1000) commissions = 0.08;
				else if (1000 <= sales && sales <= 10000) commissions = 0.12;
				else if (sales >= 10000) commissions = 0.145;
			}
			if (commissions >= -1.0)
			{
				Console.WriteLine("{0:f2}", (commissions * sales));
			}
			else

				Console.WriteLine("Error");

		}
	}
}