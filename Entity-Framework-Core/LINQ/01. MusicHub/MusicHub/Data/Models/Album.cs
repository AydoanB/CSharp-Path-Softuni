using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(40)]
        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime ReleaseDate { get; set; }

        public Decimal Price => Songs.Sum(x => x.Price);
        
        public int? ProducerId { get; set; }
        public Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}