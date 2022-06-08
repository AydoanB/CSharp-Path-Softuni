using System;

namespace _4._Password_Validator
{
	class Program
	{
		static void Main(string[] args)
		{
			ValidationPassword(Console.ReadLine());
		}
		static void ValidationPassword(string password)
		{
			string validation = PasswordLenght(password);

			if (validation != null)
			{
				Console.WriteLine(validation);
			}
			string validation2 = OnlyDigitsAndNums(password);
			string validation3 = ValidateHasTwoDigit(password);
			if (validation2 != null)
			{
				Console.WriteLine(validation);
			}

			if (validation3 != null)
			{
				Console.WriteLine(validation3);
			}

			if (validation == null && validation2 == null && validation3 == null)
			{
				Console.WriteLine("Password is valid");
			}


		}
		static string PasswordLenght(string password)
		{
			string res = null;

			int parola = password.Length;

			if (parola < 6 || parola > 10)
			{
				res = "Password must be between 6 and 10 characters";
			}
			return res;
		}
		static string OnlyDigitsAndNums(string password)
		{
			string res = null;
			for (int i = 0; i < password.Length; i++)
			{
				if (!char.IsLetterOrDigit(password[i]))
				{
					res = "Password must consist only of letters and digits";
					break;
				}
			}
			return res;
		}
		static string ValidateHasTwoDigit(string password)
		{
			int counter = 0;
			string res = "Password must have at least 2 digits";
			foreach (char c in password)
			{
				if (char.IsDigit(c))
				{
					counter++;
				}

				if (counter == 2)
				{
					break;
				}
			}
			return res;
		}
	}
}