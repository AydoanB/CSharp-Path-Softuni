using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeesDto
    {
        [Required]
        [StringLength(40), MinLength(3)]
        [RegularExpression(@"^([a-zA-Z0-9]+)$")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3})+(-\d{3})+(-\d{4})")]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}