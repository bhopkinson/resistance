using Resistance.GameModels;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Resistance.Web.Services
{
    public class GameManager : IGameManager
    {
        private readonly ConcurrentDictionary<string, Game> _games;
        private readonly ICodeGenerator _gameCodeGenerator;

        public GameManager(ICodeGenerator gameCodeGenerator)
        {
            _games = new ConcurrentDictionary<string, Game>();
            _gameCodeGenerator = gameCodeGenerator;
        }

        public string CreateGame()
        {
            var game = new Game();
            string code;

            //do
            //{
            //    code = _gameCodeGenerator.GetCode();
            //}
            //while (!_games.TryAdd(code, game));

            // TODO
            code = "0";
            _games.TryAdd("0", game);

            return code;
        }

        public Game GetGame(string gameCode)
        {
            if (_games.TryGetValue(gameCode, out var game))
            {
                return game;
            }
            else
            {
                throw new Exception("Game not found.");
            }
        }
    }
}
