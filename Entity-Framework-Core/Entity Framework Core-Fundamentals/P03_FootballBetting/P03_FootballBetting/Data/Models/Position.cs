using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        [Key] 
        public int PositionId { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players = new HashSet<Player>();

    }
}