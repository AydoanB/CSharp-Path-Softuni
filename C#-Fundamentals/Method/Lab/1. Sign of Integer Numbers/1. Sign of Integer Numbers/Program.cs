﻿using System;

namespace _1._Sign_of_Integer_Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			int number()
			{
				if (n > 0) Console.WriteLine($"The number {n} is positive.");
				if (n < 0) Console.WriteLine($"The number {n} is negative.");
				if (n == 0) Console.WriteLine($"The number {n} is zero.");
				return n;
			}
			number();
		}
	}
}
