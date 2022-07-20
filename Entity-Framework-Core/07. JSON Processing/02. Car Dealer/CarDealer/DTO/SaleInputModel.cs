using Newtonsoft.Json;

namespace CarDealer.DTO
{
    public class SaleInputModel
    {
        [JsonProperty ("carId")]
        public int CarId { get; set; }

        [JsonProperty ("customerId")]
        public int CustomerId { get; set; }
        
        [JsonProperty ("discount")]
        public double Discount { get; set; }
    }
}