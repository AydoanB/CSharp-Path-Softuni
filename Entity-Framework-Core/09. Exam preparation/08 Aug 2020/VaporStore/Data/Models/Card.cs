using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
            Purchases = new HashSet<Purchase>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"(^\d{4})( \d{4}){3}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"(^\d{3})")]
        public string Cvc { get; set; }

        public CardType Type { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}