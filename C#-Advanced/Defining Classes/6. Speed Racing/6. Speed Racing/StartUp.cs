using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carMake = Console.ReadLine().Split();
                string model = carMake[0];
                double fuelAmount = double.Parse(carMake[1]);
                double fuelConsumptionPerKm = double.Parse(carMake[2]);

                Car currentCar = new Car(model, fuelAmount, fuelConsumptionPerKm);

                cars.Add(currentCar);
            }


            while (true)
            {
                string[] driving = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string cmd = driving[0];

                if (cmd == "End")
                {
                    break;
                }

                string carModel = driving[1];
                int amountOfKm = int.Parse(driving[2]);

                Car carDrive = cars.Where(x => x.Model == carModel).ToList().First();

                carDrive.Moovable(carModel, amountOfKm);




            }

            foreach (var singleCar in cars)
            {
                Console.WriteLine($"{singleCar.Model} {singleCar.FuelAmount:f2} {singleCar.TravelledDistance}");

            }

        }
    }
}
