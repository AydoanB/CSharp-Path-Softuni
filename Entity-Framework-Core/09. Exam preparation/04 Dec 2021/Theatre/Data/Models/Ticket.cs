using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        [Key] public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public sbyte RowNumber { get; set; }

        [Required] 
        public int PlayId { get; set; }
        public Play Play { get; set; }

        [Required]
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
    }
}