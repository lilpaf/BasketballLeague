using BasketballLeagueAPI.Data;
using BasketballLeagueAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketballLeagueAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDataBase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            var data = services.GetRequiredService<BasketballLeagueDbContext>();

            data.Database.Migrate();

            SeedTeams(data);
            SeedGames(data);

            return app;
        }

        private static void SeedTeams(BasketballLeagueDbContext data)
        {
            if (data.Teams.Any())
            {
                return;
            }

            data.Teams.AddRange(new[]
            {
                new Team {Name = "Lakers"},
                new Team {Name = "Phoenix Suns"},
                new Team {Name = "New Orleans Pelicans"},
                new Team {Name = "Boston Celtics"},
                new Team {Name = "Brooklyn Nets"},
                new Team {Name = "Golden State Warriors"}
            });

            data.SaveChanges();
        }
        
        private static void SeedGames(BasketballLeagueDbContext data)
        {
            if (data.Games.Any())
            {
                return;
            }

            data.Games.AddRange(new[]
            {
                new Game {HomeTeamId = 1, AwayTeamId = 2, HomeTeamScore = 129, AwayTeamScore = 125},
                new Game {HomeTeamId = 3, AwayTeamId = 4, HomeTeamScore = 114, AwayTeamScore = 106},
                new Game {HomeTeamId = 5, AwayTeamId = 6, HomeTeamScore = 111, AwayTeamScore = 106},
                new Game {HomeTeamId = 1, AwayTeamId = 6, HomeTeamScore = 120, AwayTeamScore = 128},
                new Game {HomeTeamId = 2, AwayTeamId = 5, HomeTeamScore = 106, AwayTeamScore = 127},
                new Game {HomeTeamId = 3, AwayTeamId = 4, HomeTeamScore = 111, AwayTeamScore = 118},
                new Game {HomeTeamId = 4, AwayTeamId = 6, HomeTeamScore = 121, AwayTeamScore = 104},
                new Game {HomeTeamId = 5, AwayTeamId = 2, HomeTeamScore = 109, AwayTeamScore = 119},
                new Game {HomeTeamId = 1, AwayTeamId = 3, HomeTeamScore = 135, AwayTeamScore = 110}, 
                new Game {HomeTeamId = 4, AwayTeamId = 6, HomeTeamScore = 122, AwayTeamScore = 99},
                new Game {HomeTeamId = 2, AwayTeamId = 3, HomeTeamScore = 112, AwayTeamScore = 100},
                new Game {HomeTeamId = 1, AwayTeamId = 5, HomeTeamScore = 122, AwayTeamScore = 117}, 
                new Game {HomeTeamId = 1, AwayTeamId = 4, HomeTeamScore = 105, AwayTeamScore = 123},
                new Game {HomeTeamId = 3, AwayTeamId = 2, HomeTeamScore = 108, AwayTeamScore = 100},
                new Game {HomeTeamId = 5, AwayTeamId = 6, HomeTeamScore = 125, AwayTeamScore = 121}, 
                new Game {HomeTeamId = 6, AwayTeamId = 2, HomeTeamScore = 117, AwayTeamScore = 110},
                new Game {HomeTeamId = 1, AwayTeamId = 5, HomeTeamScore = 118, AwayTeamScore = 128},
                new Game {HomeTeamId = 4, AwayTeamId = 3, HomeTeamScore = 103, AwayTeamScore = 113}, 
                new Game {HomeTeamId = 1, AwayTeamId = 2, HomeTeamScore = 113, AwayTeamScore = 120},
                new Game {HomeTeamId = 3, AwayTeamId = 4, HomeTeamScore = 114, AwayTeamScore = 117},
                new Game {HomeTeamId = 5, AwayTeamId = 6, HomeTeamScore = 109, AwayTeamScore = 128}
            });

            data.SaveChanges();
        }
    }
}
