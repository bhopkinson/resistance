using Resistance.Web.Models;

namespace Resistance.Web.Services
{
    public class GameStateManager : IGameStateManager
    {
        private static GameOverview _game;

        public GameStateManager()
        {
            CreateGame();
        }

        public GameOverview GetGame(string gameId)
        {
            return _game;
        }

        public GameOverview CreateGame()
        {
            _game = new GameOverview("Enable");
            return _game;
        }
    }
}
