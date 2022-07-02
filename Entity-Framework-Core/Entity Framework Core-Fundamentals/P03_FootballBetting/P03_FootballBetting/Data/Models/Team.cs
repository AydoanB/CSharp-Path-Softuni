using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
       
        [Key]
        public int TeamId { get; set; }

        public string Name { get; set; }

        [Url]
        public string LogoUrl { get; set; }

        [Column(TypeName = "char(3)")]
        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<Player> Players = new HashSet<Player>();
        
        public ICollection<Game> HomeGames = new HashSet<Game>();
        
        public ICollection<Game> AwayGames = new HashSet<Game>();

    }
}