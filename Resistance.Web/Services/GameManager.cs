using DynamicData;
using DynamicData.Binding;
using Resistance.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resistance.Web.Services
{
    public class GameManager : IGameManager, IDisposable
    {
        private readonly SourceCache<Game, string> _games;
        private readonly ICodeGenerator _gameCodeGenerator;

        private readonly IDisposable _gameCodeSubscription;

        public IObservableCollection<string> GameCodes { get; } = new ObservableCollectionExtended<string>();

        public GameManager(ICodeGenerator gameCodeGenerator)
        {
            _games = new SourceCache<Game, string>(g => g.Code);
            _gameCodeSubscription = _games
                .Connect()
                .RemoveKey()
                .Transform(g => g.Code)
                .Bind(GameCodes)
                .Subscribe();

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

        public ICollection<Game> GetAllGames() => _games.Items.ToArray();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _gameCodeSubscription.Dispose();
                }

                disposedValue = true;
            }
        }
        
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
