using System;

namespace ClassAnimal
{
	class Program
	{
		static void Main(string[] args)
		{
			string animal = Console.ReadLine();

			switch(animal)
			{
				case "dog": Console.WriteLine("mammal");
					break;
				case "snake": Console.WriteLine("reptile");
					break;
				default: Console.WriteLine("other");
					break;
				
			}
		}
	}
}
