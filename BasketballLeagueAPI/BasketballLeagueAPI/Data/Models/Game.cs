using System.ComponentModel.DataAnnotations.Schema;

namespace BasketballLeagueAPI.Data.Models
{
    public class Game
    {
        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        [ForeignKey(nameof(HomeTeamId))]
        public Team HomeTeam { get; set; }
        
        public int AwayTeamId { get; set; }

        [ForeignKey(nameof(AwayTeamId))]
        public Team AwayTeam { get; set; }

        //[Range(ScoreMinRange, ScoreMaxRange)]
        public int HomeTeamScore { get; set; }

        //[Range(ScoreMinRange, ScoreMaxRange)]
        public int AwayTeamScore { get; set; }
    }
}
