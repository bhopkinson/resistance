using MediatR;

namespace Resistance.Web.Dispatchers.Models
{
    public class GameBoardMission : INotification
    {
        public MissionState State { get; set; }
        public int FailsRequired { get; set; }
        public int MissionNo { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}