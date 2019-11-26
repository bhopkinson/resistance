using System.Collections.Generic;

namespace Resistance.Web.Dispatchers.DispatchModels
{
    public class GameBoardNotification
    {
        public List<GameBoardMission> Missions { get; set; }
        public int VoteCount { get; set; }
        public string Leader { get; set; }
    }
}
