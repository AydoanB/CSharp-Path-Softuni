using MusicHub.Data.Models;

namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;

    public class MusicHubDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Performer> Performers { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<SongPerformer> SongsPerformers { get; set; }
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>(e => e.HasKey(e => new { e.SongId, e.PerformerId }));
            
            builder.Entity<Writer>(entity => 
                entity.HasMany(s => s.Songs).WithOne(w => w.Writer).HasForeignKey(fk => fk.WriterId));

            builder.Entity<Album>(e => 
                e.HasMany(s => s.Songs).WithOne(a => a.Album).HasForeignKey(fk => fk.AlbumId));

            builder.Entity<Producer>(e =>
                e.HasMany(a => a.Albums).WithOne(p => p.Producer).HasForeignKey(fk => fk.ProducerId));
        }
    }
}
