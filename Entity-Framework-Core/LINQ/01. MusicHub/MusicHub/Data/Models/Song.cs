using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MusicHub.Data.Models.Enums;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(20)]
        [Required]
        public string Name { get; set; }

        public TimeSpan Duration{ get; set; }
        
        public DateTime CreatedOn{ get; set; }
        
        public Genre Genre{ get; set; }
        
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
        
        [Required]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        public Decimal Price { get; set; }

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }

    }
}