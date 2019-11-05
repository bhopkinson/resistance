using Resistance.GameModel.enums;

namespace Resistance.GameModel
{
    public class Accusation
    {
        public Team Team { get; set; }
        public Player Accused { get; set; }
        public AccusationOutcome State { get; set; }
    }
}
