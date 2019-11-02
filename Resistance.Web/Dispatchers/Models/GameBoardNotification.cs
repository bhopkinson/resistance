using System.Collections.Generic;
using MediatR;

namespace Resistance.Web.Dispatchers.Models
{
    public class GameBoardNotification : INotification
    {
        public List<GameBoardMission> Missions { get; set; }
        public int VoteCount { get; set; }
        public string Leader { get; set; }
    }
}
