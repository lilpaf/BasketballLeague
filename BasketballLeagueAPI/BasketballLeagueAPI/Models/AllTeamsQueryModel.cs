namespace BasketballLeagueAPI.Models
{
    public class AllTeamsQueryModel
    {
        public const int TeamsPerPage = 3;

        public string? SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;
    }
}
