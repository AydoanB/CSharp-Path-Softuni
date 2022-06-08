using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Man_O_War
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] PirateShip = Console.ReadLine()
				.Split(">")
				.Select(int.Parse).ToArray();

			int[] WarShip = Console.ReadLine()
				.Split(">")
				.Select(int.Parse).ToArray();

			int maxHealthSection = int.Parse(Console.ReadLine());
			string input = null;
			bool isBroken = false;

			while ((input = Console.ReadLine()) != "Retire")
			{
				string[] commandArgs = input.Split(" ");
				string command = commandArgs[0];
				int index = -1;

				int damage = 0;

				switch (command)
				{
					case "Fire":
						index = int.Parse(commandArgs[1]);
						damage = int.Parse(commandArgs[2]);

						if (index >= 0 && index < WarShip.Length)
						{
							WarShip[index] -= damage;

							if (WarShip[index] <= 0)
							{
								Console.WriteLine("You won! The enemy ship has sunken.");
								isBroken = true;
							}
						}

						
						break;

					case "Defend":
						index = int.Parse(commandArgs[1]);
						int endIndex = int.Parse(commandArgs[2]);
						damage = int.Parse(commandArgs[3]);

						if (index >= 0 && index < PirateShip.Length &&
							endIndex < PirateShip.Length && endIndex > 0)
						{

							for (int i = index; i <= endIndex; i++)
							{
								PirateShip[i] -= damage;

								if (PirateShip[i] <= 0)
								{
									Console.WriteLine("You lost! The pirate ship has sunken.");
									isBroken = true;
									break;
								}
							}
						}

						break;

					case "Repair":
						index = int.Parse(commandArgs[1]);
						int health = int.Parse(commandArgs[2]);

						if (index >= 0 && index < PirateShip.Length)
						{
							PirateShip[index] += health;
							if (PirateShip[index] > maxHealthSection)
							{
								PirateShip[index] = maxHealthSection;
							}
						}

						break;

					case "Status":
						int count = 0;
						foreach (int section in PirateShip)
						{
							double temp = 0.2 * maxHealthSection;

							if (section < temp)
							{
								count++;
							}

							
						}

						Console.WriteLine($"{count} sections need repair.");

						break;
				}

				if (isBroken)
				{
					break;

				}
			}

			if (!isBroken)
			{
				int pirateShipSum = 0;
				int warshipSum = 0;
				foreach (int i in PirateShip)
				{
					pirateShipSum += i;
				}
				foreach (int i in WarShip)
				{
					warshipSum += i;
				}
				Console.WriteLine($"Pirate ship status: {pirateShipSum}");
				Console.WriteLine($"Warship status: {warshipSum}");
			}


		}
	}
}
