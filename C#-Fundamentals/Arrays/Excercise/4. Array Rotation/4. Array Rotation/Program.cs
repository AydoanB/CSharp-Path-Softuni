using System;

namespace _4._Array_Rotation
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] arr = Console.ReadLine().Split();
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string first = arr[0];

				for (int index = 1; index < arr.Length; index++)
				{
					string curr = arr[index];
					arr[index - 1] = curr;
				}
				arr[arr.Length - 1] = first;
			}
			
			Console.WriteLine(string.Join(" ", arr));

		}
	}
}
