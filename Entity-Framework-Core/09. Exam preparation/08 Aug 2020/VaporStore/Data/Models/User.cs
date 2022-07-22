using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
            Cards = new HashSet<Card>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]{3,}(?: [A-Z][a-z]*){0,2}$")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}