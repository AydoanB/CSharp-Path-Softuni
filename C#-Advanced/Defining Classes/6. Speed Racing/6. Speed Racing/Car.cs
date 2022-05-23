using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuel, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuel;
            this.FuelConsumptionPerKilometer = fuelConsumption;
            this.TravelledDistance = 0;


        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }


        public void Moovable(string model, int km)
        {
            var usedFuel = km * this.FuelConsumptionPerKilometer;
            if (usedFuel > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= usedFuel;
                this.TravelledDistance += km;
            }


        }
    }
}
