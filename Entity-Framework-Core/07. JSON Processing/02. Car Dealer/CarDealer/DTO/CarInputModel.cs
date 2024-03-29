﻿using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class CarInputModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public ICollection<int> partsId { get; set; }
    }
}