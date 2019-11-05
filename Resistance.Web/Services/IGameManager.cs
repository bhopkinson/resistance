using Resistance.GameModels;

namespace Resistance.Web.Services
{
    public interface IGameManager
    {
        public string CreateGame();
        public Game GetGame(string gameId);
    }
}
