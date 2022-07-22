using System;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression(@"^([A-Za-z0-9]{4})(-[A-Za-z0-9]{4}){2}")]
        public string ProductKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CardId { get; set; }
        public Card Card { get; set; }

        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }

    }
}