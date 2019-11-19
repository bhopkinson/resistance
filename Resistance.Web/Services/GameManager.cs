using Resistance.GameModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

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
            lock (_games)
            {
                string code;

                do
                {
                    code = _gameCodeGenerator.GetCode();
                }
                while (_games.Keys.Contains(code));

                var game = new Game(code);
                _games.TryAdd(code, game);

                return code;
            }
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

        public ICollection<Game> GetAllGames() => _games.Values;
    }
}
