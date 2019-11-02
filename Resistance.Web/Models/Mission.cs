using Resistance.Web.Models.enums;
using System.Collections.Generic;

namespace Resistance.Web.Models
{
    public class Mission
    {
        public Mission(int number, int teamSize)
        {
            Number = number;
            TeamSize = teamSize;
            Picks = new List<MissionTeam>();
            MissionState = MissionState.NotStarted;
        }

        public int Number { get; set; }
        public int TeamSize { get; set; }
        public ICollection<MissionTeam> Picks { get; set; }
        public MissionTeam Team { get; set; }
        public MissionState MissionState { get; set; }
        public ICollection<PlayerOutcome> PlayerOutcomes { get; set; }
        public ICollection<Player> RevealedPlayers { get; set; }
        public Accusation Accusation { get; set; }
        public Investigation Investigation { get; set; }
    }
}
