using Resistance.Web.Models.enums;

namespace Resistance.Web.Models
{
    public class Accusation
    {
        public Team Team { get; set; }
        public Player Accused { get; set; }
        public AccusationOutcome State { get; set; }
    }
}
