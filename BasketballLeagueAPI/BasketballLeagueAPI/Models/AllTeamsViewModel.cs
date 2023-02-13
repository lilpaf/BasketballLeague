namespace BasketballLeagueAPI.Models
{
    public class AllTeamsViewModel
    {
        public int TotalTeams { get; init; }

        public int TeamsPerPage { get; init; }

        public IEnumerable<TeamsListingViewModel> Teams { get; init; }
    }
}
