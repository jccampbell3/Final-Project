using Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Data;

public class ArenaDbContext : DbContext {
    public ArenaDbContext(DbContextOptions<ArenaDbContext> options) : base(options) { }

    public DbSet<Player> Players { get; set; }
    public DbSet<Boss> Bosses { get; set; }
    public DbSet<HighScore> HighScores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<HighScore>()
            .HasIndex(h => new { h.PlayerId, h.BossId })
            .IsUnique();
    }
}