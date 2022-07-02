using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }

        public string Name { get; set; }
       
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public ICollection<Team> HostedTeams = new HashSet<Team>();
    }
}