using BasketballLeagueAPI.Data.Models;
using BasketballLeagueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketballLeagueAPI.Data
{
    public class BasketballLeagueDbContext : DbContext
    {
        public BasketballLeagueDbContext(DbContextOptions<BasketballLeagueDbContext> options) : base(options) 
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeamsListingViewModel>().HasNoKey().ToView(null);
            
            modelBuilder.Entity<GamesListingViewModel>().HasNoKey().ToView(null);
            
            modelBuilder.Entity<GamesAndTeamsTotalCountModel>().HasNoKey().ToView(null);

            base.OnModelCreating(modelBuilder);
        }
    }
}
