using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatersAndTicketsDto
    {
        [StringLength(30), MinLength(4)]
        [Required]
        public string Name { get; set; }

        [Range(1, 10)]
        [Required]
        public sbyte NumberOfHalls { get; set; }

        [StringLength(30), MinLength(4)]
        [Required]
        public string Director { get; set; }

        public ICollection<ImportTicketsDto> Tickets { get; set; }
    }

    public class ImportTicketsDto
    {
        [Range(1.00, 100.00)]
        [Required]
        public decimal Price { get; set; }

        [Range(1, 10)]
        [Required]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}