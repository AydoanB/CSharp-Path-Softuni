using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersDto
    {
        [Required]
        [RegularExpression(@"^[A-Z][a-z]{3,}(?: [A-Z][a-z]*){0,2}$")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20), MinLength(3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(0, 103)]
        public int Age { get; set; }

        public ICollection<ImportCardsDto> Cards { get; set; }
    }

    public class ImportCardsDto
    {
        public string Number { get; set; }
        public string Cvc { get; set; }
    }
}