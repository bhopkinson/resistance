using MediatR;

namespace Resistance.Web.Dispatchers.DispatchModels
{
    public class GameBoardMission : IRequest
    {
        public MissionState State { get; set; }
        public int FailsRequired { get; set; }
        public int MissionNo { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}