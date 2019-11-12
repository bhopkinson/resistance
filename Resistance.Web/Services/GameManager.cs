using DynamicData;
using DynamicData.Binding;
using Resistance.GameModels;
using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Linq;

namespace Resistance.Web.Services
{
    public class GameManager : IGameManager
    {
        private readonly SourceCache<Game, string> _games;
        private readonly ICodeGenerator _gameCodeGenerator;

        public GameManager(ICodeGenerator gameCodeGenerator)
        {
            _games = new SourceCache<Game, string>(g => g.Code);

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
                _games.AddOrUpdate(game);

                return code;
            }
        }

        public Game GetGame(string gameCode)
        {
            var game = _games.Lookup(gameCode);

            if (!game.HasValue)
            {
                throw new Exception("Game not found.");
            }

            return game.Value;
        }
    }
}
