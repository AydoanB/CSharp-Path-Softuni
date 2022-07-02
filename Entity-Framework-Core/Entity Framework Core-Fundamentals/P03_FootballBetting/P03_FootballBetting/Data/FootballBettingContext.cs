using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Team>(t =>
                t.HasOne(t => t.Town).WithMany(to => to.HostedTeams).HasForeignKey(f => f.TeamId));



            //For Town
            modelBuilder.Entity<Town>(e => e
                .HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId));

            //For Player
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(t => t.Team).WithMany(p => p.Players).HasForeignKey(fk => fk.TeamId);
                entity.HasOne(p => p.Position).WithMany(p => p.Players).HasForeignKey(fk => fk.PositionId);
            });

            //For PlayerStatistics
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(k => new { k.GameId, k.PlayerId });
                entity.HasOne(p => p.Player).WithMany(p => p.Statistics).HasForeignKey(fk => fk.PlayerId);
                entity.HasOne(g => g.Game).WithMany(p => p.Statistics).HasForeignKey(fk => fk.GameId);
            });

            //For Game
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(ht => ht.HomeTeam).WithMany(hg=>hg.HomeGames).HasForeignKey(fk=>fk.HomeTeamId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(at => at.AwayTeam).WithMany(at=>at.AwayGames).HasForeignKey(fk=>fk.AwayTeamId).OnDelete(DeleteBehavior.Restrict);
            });

            //For Bet
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasOne(p => p.User).WithMany(b => b.Bets).HasForeignKey(fk => fk.UserId);
                entity.HasOne(g => g.Game).WithMany(b => b.Bets).HasForeignKey(fk => fk.GameId);
            });

           




        }
    }
}