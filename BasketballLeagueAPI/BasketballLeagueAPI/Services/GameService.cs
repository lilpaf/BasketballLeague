using BasketballLeagueAPI.Data;
using BasketballLeagueAPI.Models;
using Microsoft.EntityFrameworkCore;
using static BasketballLeagueAPI.Models.AllGamesQueryModel;

namespace BasketballLeagueAPI.Services
{
    public class GameService : IGameService
    {
        private readonly BasketballLeagueDbContext _dbContext;
        public GameService(BasketballLeagueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AllGamesViewModel> GetAllGames(AllGamesQueryModel query)
        {
            var games = await _dbContext
               .Set<GamesListingViewModel>()
               .FromSql($"EXEC spGetAllGames {query.CurrentPage}, {GamesPerPage}")
               .ToListAsync();

            var totalGames = _dbContext
                .Set<GamesAndTeamsTotalCountModel>()
                .FromSqlRaw("spGetTotalGames")
                .AsEnumerable()
                .FirstOrDefault();

            return new AllGamesViewModel 
            { 
                Games = games, 
                TotalGames = totalGames.TotalCount,
                GamesPerPage = AllGamesQueryModel.GamesPerPage
            };
        }
        
        public async Task<GamesListingViewModel> GetHighlightMatch()
        {
            var game = await _dbContext
               .Set<GamesListingViewModel>()
               .FromSqlRaw("spGetHighlightMatch")
               .ToListAsync();

            return game.FirstOrDefault();
        }
    }
}
