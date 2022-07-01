using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //For Team
            modelBuilder.Entity<Team>(t => t
                .HasOne(pk => pk.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(c => c.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Team>(t => t
                .HasOne(pk => pk.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(c => c.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Cascade));

            //For Town
            modelBuilder.Entity<Town>(e => e
                .HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId));

            modelBuilder.Entity<Game>(g=>g.HasOne(ht=>ht.HomeTeam)
                .WithMany(t=>t.))
            
            //For PlayerStatistics
            modelBuilder.Entity<PlayerStatistics>(e => e.HasKey(k => new { k.GameId, k.PlayerId }));

            

           


        }
    }
}