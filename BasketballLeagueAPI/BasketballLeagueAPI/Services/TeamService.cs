using BasketballLeagueAPI.Data;
using BasketballLeagueAPI.Models;
using Microsoft.EntityFrameworkCore;
using static BasketballLeagueAPI.Models.AllTeamsQueryModel;

namespace BasketballLeagueAPI.Services
{
    public class TeamService : ITeamService
    {
        private readonly BasketballLeagueDbContext _dbContext;
        public TeamService(BasketballLeagueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AllTeamsViewModel> GetAllTeams(AllTeamsQueryModel query)
        {
            GamesAndTeamsTotalCountModel totalTeams;

            var teams = await _dbContext
                .Set<TeamsListingViewModel>()
                .FromSql($"EXEC spGetAllTeams {query.CurrentPage}, {TeamsPerPage}, {query.SearchTerm}")
                .ToListAsync();

            if (string.IsNullOrEmpty(query.SearchTerm))
            {
                totalTeams = _dbContext
               .Set<GamesAndTeamsTotalCountModel>()
               .FromSqlRaw("spGetTotalTeams")
               .AsEnumerable()
               .FirstOrDefault();

                return new AllTeamsViewModel 
                { 
                    Teams = teams, 
                    TotalTeams = totalTeams.TotalCount,
                    TeamsPerPage = AllTeamsQueryModel.TeamsPerPage
                };
            }

            totalTeams = _dbContext
               .Set<GamesAndTeamsTotalCountModel>()
               .FromSqlRaw("spGetTotalTeams")
               .AsEnumerable()
               .FirstOrDefault();

            return new AllTeamsViewModel
            {
                Teams = teams,
                TotalTeams = totalTeams.TotalCount,
                TeamsPerPage = AllTeamsQueryModel.TeamsPerPage
            };
        }
        
        public async Task<IEnumerable<TeamsListingViewModel>> GetTopFiveOffensiveTeams()
        {
            var teams = await _dbContext
                .Set<TeamsListingViewModel>()
                .FromSqlRaw("spGetTopFiveOffensiveTeams")
                .ToListAsync();

            return teams;
        }
        
        public async Task<IEnumerable<TeamsListingViewModel>> GetTopFiveDefensiveTeams()
        {
            var teams = await _dbContext
                .Set<TeamsListingViewModel>()
                .FromSqlRaw("spGetTopFiveDefensiveTeams")
                .ToListAsync();

            return teams;
        }
    }
}
