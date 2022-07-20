using Theatre.Data.Models;

namespace Theatre.Data
{
    using Microsoft.EntityFrameworkCore;

    public class TheatreContext : DbContext
    {
       public DbSet<Models.Theatre> Theatres { get; set; }
        public DbSet<Play>Plays { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
       public TheatreContext() { }

        public TheatreContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
