using Resistance.Web.Models;

namespace Resistance.Web.Services
{
    public class GameManager : IGameManager
    {
        private static Game _game;
        private readonly ICodeGenerator _gameCodeGenerator;

        public GameManager(ICodeGenerator gameCodeGenerator)
        {
            _gameCodeGenerator = gameCodeGenerator;
        }

        public string CreateGame()
        {
            var code = _gameCodeGenerator.GetCode();

            _game = new Game(code);

            return code;
        }

        public Game GetGame(string gameId)
        {
            return _game;
        }
    }
}
