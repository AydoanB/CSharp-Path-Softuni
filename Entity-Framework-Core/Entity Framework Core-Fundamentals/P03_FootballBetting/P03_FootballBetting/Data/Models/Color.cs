using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
       
        [Key]
        public int ColorId { get; set; }

        public string Name { get; set; }
        public  ICollection<Team> PrimaryKitTeams = new HashSet<Team>();

        public  ICollection<Team> SecondaryKitTeams = new HashSet<Team>();

    }
}