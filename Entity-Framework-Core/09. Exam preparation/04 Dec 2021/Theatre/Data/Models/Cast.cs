﻿using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required] 
        public string PhoneNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
        public Play Play { get; set; }
    }
}