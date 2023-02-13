using Microsoft.AspNetCore.Mvc;
using BasketballLeagueAPI.Models;
using BasketballLeagueAPI.Services;
using Microsoft.Extensions.Caching.Memory;

namespace BasketballLeagueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMemoryCache _memoryCache;
        public GameController(IGameService gameService, IMemoryCache memoryCache)
        {
            _gameService = gameService;
            _memoryCache = memoryCache;
        }

        [HttpGet("~/Games")]
        public async Task<ActionResult<AllGamesViewModel>> Games([FromQuery] AllGamesQueryModel query)
        {
            return Ok(await _gameService.GetAllGames(query));
        }

        [HttpGet("~/HighlightMatch")]
        public async Task<ActionResult<GamesListingViewModel>> HighlightMatch()
        {
            const string HighlightMatchCacheKey = "HighlightMatch";

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

            if (_memoryCache.TryGetValue(HighlightMatchCacheKey, out GamesListingViewModel highlightMatch))
            {
                return Ok(highlightMatch);
            }

            highlightMatch = await _gameService.GetHighlightMatch();

            _memoryCache.Set(HighlightMatchCacheKey, highlightMatch, cacheOptions);

            return Ok(highlightMatch);
        }
    }
}
