using Resistance.Web.Models;

namespace Resistance.Web.Services
{
    public interface IGameStateManager
    {
        public GameOverview GetGame(string gameId);
        public GameOverview CreateGame();
    }
}
