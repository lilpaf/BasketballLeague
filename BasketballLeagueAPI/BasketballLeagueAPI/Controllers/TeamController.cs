using BasketballLeagueAPI.Models;
using BasketballLeagueAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BasketballLeagueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMemoryCache _memoryCache;
        public TeamController(ITeamService teamService, IMemoryCache memoryCache)
        {
            _teamService = teamService;
            _memoryCache = memoryCache;
        }

        [HttpGet("~/Teams")]
        public async Task<ActionResult<AllTeamsViewModel>> Teams([FromQuery] AllTeamsQueryModel query)
        {
            return Ok(await _teamService.GetAllTeams(query));
        }

        [HttpGet("~/TopFiveOffensiveTeams")]
        public async Task<ActionResult<IEnumerable<TeamsListingViewModel>>> TopFiveOffensiveTeams()
        {
            const string TeamListCacheKey = "TopFiveOffensiveTeamsList";

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

            if (_memoryCache.TryGetValue(TeamListCacheKey, out IEnumerable<TeamsListingViewModel> teams))
            {
                return Ok(teams);
            }

            teams = await _teamService.GetTopFiveOffensiveTeams();

            _memoryCache.Set(TeamListCacheKey, teams, cacheOptions);

            return Ok(teams);
        }

        [HttpGet("~/TopFiveDefensiveTeams")]
        public async Task<ActionResult<IEnumerable<TeamsListingViewModel>>> TopFiveDefensiveTeams()
        {
            const string TeamListCacheKey = "TopFiveDefensiveTeamsList";

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

            if (_memoryCache.TryGetValue(TeamListCacheKey, out IEnumerable<TeamsListingViewModel> teams))
            {
                return Ok(teams);
            }

            teams = await _teamService.GetTopFiveDefensiveTeams();

            _memoryCache.Set(TeamListCacheKey, teams, cacheOptions);

            return Ok(teams);
        }
    }
}
