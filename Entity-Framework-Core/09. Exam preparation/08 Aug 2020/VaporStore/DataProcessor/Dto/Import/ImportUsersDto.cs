using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersDto
    {
        [Required]
        [RegularExpression(@"^[A-Z][a-z]*(?: [A-Z][a-z]*)$")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20), MinLength(3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public ICollection<ImportCardsDto> Cards { get; set; }
    }

    public class ImportCardsDto
    {

        [Required]
        [RegularExpression(@"(^\d{4})( \d{4}){3}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"(^\d{3})")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}