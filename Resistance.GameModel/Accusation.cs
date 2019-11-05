using Resistance.GameModels.enums;

namespace Resistance.GameModels
{
    public class Accusation
    {
        public Team Team { get; set; }
        public Player Accused { get; set; }
        public AccusationOutcome State { get; set; }
    }
}
