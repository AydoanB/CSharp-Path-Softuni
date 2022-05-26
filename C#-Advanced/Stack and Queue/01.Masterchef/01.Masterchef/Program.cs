using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int dippingSauce = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;

            Queue<int> ingridients = new Queue<int>(input1);
            Stack<int> freshness = new Stack<int>(input2);
            Dictionary<string, int> preparedDishes = new Dictionary<string, int>();
            preparedDishes.Add("Dipping sauce", 0);
            preparedDishes.Add("Green salad", 0);
            preparedDishes.Add("Chocolate cake", 0);
            preparedDishes.Add("Lobster", 0);

            while (ingridients.Any() && freshness.Any())
            {
                int currentIngidient = ingridients.Peek();
                int currentFreshness = freshness.Peek();

                if (currentIngidient == 0)
                {
                    ingridients.Dequeue();
                    continue;

                }

                if (currentIngidient * currentFreshness == 150)
                {
                    ingridients.Dequeue();
                    freshness.Pop();
                    preparedDishes["Dipping sauce"]++;
                    dippingSauce++;
                }
                else if (currentIngidient * currentFreshness == 250)
                {
                    ingridients.Dequeue();
                    freshness.Pop();
                    preparedDishes["Green salad"]++;
                    greenSalad++;
                }
                else if (currentIngidient * currentFreshness == 300)
                {
                    ingridients.Dequeue();
                    freshness.Pop();
                    preparedDishes["Chocolate cake"]++;
                    chocolateCake++;
                }
                else if (currentIngidient * currentFreshness == 400)
                {
                    ingridients.Dequeue();
                    freshness.Pop();
                    preparedDishes["Lobster"]++;
                    lobster++;
                }

                else
                {
                    freshness.Pop();
                    currentIngidient += 5;
                    ingridients.Enqueue(currentIngidient);
                    ingridients.Dequeue();
                }



                var sum = ingridients.Sum();
                if (preparedDishes.Any())
                {

                    Console.WriteLine("Applause! The judges are fascinated by your dishes! ");
                    if (sum != 0)
                    {
                        Console.WriteLine($"Ingredients left: {sum}");
                    }

                    foreach (var dish in preparedDishes.OrderBy(x => x.Key))
                    {
                        Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                    }

                }
                else
                {
                    Console.WriteLine("You were voted off. Better luck next year.");
                    if (sum != 0)
                    {
                        Console.WriteLine($"Ingredients left: {sum}");
                    }

                    foreach (var dish in preparedDishes.OrderBy(x => x.Key))
                    {
                        if (dish.Value > 0)
                        {
                            Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                        }

                    }



                }
            }
        }
    }
}
