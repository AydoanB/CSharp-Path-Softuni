using System;

namespace Centuries_to_minutes
{
	class Program
	{
		static void Main(string[] args)
		{
			int centuries = int.Parse(Console.ReadLine());

			var year = centuries * 100;
			var month = year * 12;
			var day = year * 365.2422;
			var hours = day * 24;
			var min = hours * 60;

		}
	}
}
