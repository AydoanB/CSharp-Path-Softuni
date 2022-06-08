using System;

namespace Login
{
	class Program
	{
		static void Main(string[] args)
		{
			string username = Console.ReadLine();
			string correct = "";

			for (int i = username.Length - 1; i >= 0; i--)
			{
				correct += username[i];
			}
			string pass = Console.ReadLine();
			int coun = 1;
			bool blocked = false;

			while (pass != correct)
			{

				if (coun == 4)
				{
					Console.WriteLine($"User {username} is blocked");
					blocked = true;
					break;
				}

				coun++;
				Console.WriteLine("Incorrect password. Try again.");
				pass = Console.ReadLine();



				if (!blocked)
				{
					Console.WriteLine($"User {username} logged in.");
				}
			}


		}
	}
}

