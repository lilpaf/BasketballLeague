using System.ComponentModel.DataAnnotations;
using static BasketballLeagueAPI.Data.DataConstraints;

namespace BasketballLeagueAPI.Data.Models
{
    public class Team
    {
        public int Id { get; set; }

        [MaxLength(TeamNameMaxLength)]
        [Required]
        public string Name { get; set; }

        public ICollection<Game> HomeGames { get; set;} = new HashSet<Game>();
        public ICollection<Game> AwayGames { get; set;} = new HashSet<Game>();
    }
}
