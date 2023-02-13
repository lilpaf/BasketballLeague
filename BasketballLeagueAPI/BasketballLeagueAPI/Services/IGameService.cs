using BasketballLeagueAPI.Models;

namespace BasketballLeagueAPI.Services
{
    public interface IGameService
    {
        public Task<AllGamesViewModel> GetAllGames(AllGamesQueryModel query);

        public Task<GamesListingViewModel> GetHighlightMatch();
    }
}
