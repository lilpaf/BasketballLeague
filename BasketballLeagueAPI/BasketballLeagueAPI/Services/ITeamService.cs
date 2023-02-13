using BasketballLeagueAPI.Models;

namespace BasketballLeagueAPI.Services
{
    public interface ITeamService
    {
        public Task<AllTeamsViewModel> GetAllTeams(AllTeamsQueryModel query);

        public Task<IEnumerable<TeamsListingViewModel>> GetTopFiveOffensiveTeams();

        public Task<IEnumerable<TeamsListingViewModel>> GetTopFiveDefensiveTeams();
    }
}
