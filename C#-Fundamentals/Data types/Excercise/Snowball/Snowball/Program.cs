using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowball
{
	class Program
	{
		static void Main(string[] args)
		{

			int n = int.Parse(Console.ReadLine());
			PrintSnowballValue(n);
		}
		private static void PrintSnowballValue(int n)
		{
			BigInteger snowballValue = -999999999;

			int Snow = 0;
			int Time = 0;
			int Quality = 0;

			for (int i = 0; i < n; i++)
			{
				int snowballSnow = int.Parse(Console.ReadLine());
				int snowballTime = int.Parse(Console.ReadLine());
				int snowballQuality = int.Parse(Console.ReadLine());

				BigInteger snowballValueCurrent = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

				if (snowballValueCurrent > snowballValue)
				{
					snowballValue = snowballValueCurrent;
					Snow = snowballSnow;
					Time = snowballTime;
					Quality = snowballQuality;
				}
			}

Console.WriteLine($"{Snow} : {Time} = {snowballValue} ({Quality})");
		}
	}
}
