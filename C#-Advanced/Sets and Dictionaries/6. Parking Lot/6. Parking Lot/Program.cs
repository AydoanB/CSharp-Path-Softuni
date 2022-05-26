using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            string inp = null;
            while ((inp = Console.ReadLine()) != "END")
            {
                var input = inp.Split(", ");
                var direction = input[0];
                var plate = input[1];


                if (direction == "IN")
                {
                    parkingLot.Add(plate);
                }
                else if (direction == "OUT")
                {
                    parkingLot.Remove(plate);
                }
            }

            if (parkingLot.Any())
            {
                foreach (var cars in parkingLot)
                {
                    Console.WriteLine(cars);
                }
            }
            else Console.WriteLine("Parking Lot is Empty");
        }
    }
}
