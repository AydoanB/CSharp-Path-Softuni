using System;

namespace ToyShop
{
	class Program
	{
		static void Main(string[] args)
		{
			double holidayPrice = double.Parse(Console.ReadLine());

			int puzzle = int.Parse(Console.ReadLine());
			int doll = int.Parse(Console.ReadLine());
			int bear = int.Parse(Console.ReadLine());
			int minnion = int.Parse(Console.ReadLine());
			int truck = int.Parse(Console.ReadLine());

			double puzzlePrice = 2.60;
			double dollPrice = 3;
			double bearPrice = 4.10;
			double minnionPrice = 8.20;
			double truckPrice = 2;

			double sum = 0;
			double discount = 0.0;
			double earnings = 0;
			double totalPrice = 0;

			sum = (puzzle * puzzlePrice) + (doll * dollPrice) + (bear * bearPrice) + (minnion * minnionPrice) + (truck * truckPrice);

			if (bear + puzzle + doll + minnion + truck > 50)
			{
				discount = sum * 0.25;
			}
			totalPrice=sum - discount;
			totalPrice = totalPrice - (totalPrice * 0.10);

			if (holidayPrice <= totalPrice) Console.WriteLine("Yes! {0:f2} lv left", totalPrice-holidayPrice);
			else Console.WriteLine("Not enough money! {0:f2} lv needed", Math.Abs(totalPrice-holidayPrice));



		}
	}
}
