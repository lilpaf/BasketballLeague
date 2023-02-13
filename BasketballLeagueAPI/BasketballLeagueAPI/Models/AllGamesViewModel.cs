namespace BasketballLeagueAPI.Models
{
    public class AllGamesViewModel
    {
        public int TotalGames { get; init; }
        
        public int GamesPerPage { get; init; }

        public IEnumerable<GamesListingViewModel> Games { get; init; }
    }
}
