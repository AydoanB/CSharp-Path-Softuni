using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Castle.Components.DictionaryAdapter;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamsDto
    {
        [Required]
        [StringLength(40),MinLength(3)]
        [RegularExpression(@"[A-Za-z0-9 .-]+")]
        public string Name { get; set; }

        [Required]
        [StringLength(40),MinLength(2)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }

}