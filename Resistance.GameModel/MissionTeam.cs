using System.Collections.Generic;
using System.Linq;

namespace Resistance.GameModels
{
    public class MissionTeam
    {
        public Player Leader { get; set; }
        public IEnumerable<Player> Members { get; set; }
        public Player Investigator { get; set; }
        public List<Vote> Votes { get; set; }
        public bool Outcome
        {
            get
            {
                var upVotes = Votes.Where(o => o.Accepted).Count();
                var downVotes = Votes.Where(o => !o.Accepted).Count();

                return upVotes > downVotes;
            }
        }
    }
}

