namespace BasketballLeagueAPI.Models
{
    public class AllGamesQueryModel
    {
        public const int GamesPerPage = 11;

        public int CurrentPage { get; init; } = 1;
    }
}
