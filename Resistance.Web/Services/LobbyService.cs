using AutoMapper;
using System;
using System.Collections.Specialized;
using System.Linq;

namespace Resistance.Web.Services
{
    public class LobbyService : ILobbyService, IDisposable
    {
        private IMapper _mapper;
        private IGameManager _gameManager;
        private IClientMessageDispatcher _clientMessageDispatcher;

        public LobbyService(
            IMapper mapper,
            IGameManager gameManager,
            IClientMessageDispatcher clientMessageDispatcher)
        {
            _mapper = mapper;
            _gameManager = gameManager;
            _clientMessageDispatcher = clientMessageDispatcher;

            _gameManager.GameCodes.CollectionChanged += GameCodes_CollectionChanged;
        }

        public string CreateGame() =>
            _gameManager.CreateGame();

        private void GameCodes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) =>
            _clientMessageDispatcher.PublishLobbyGameCodes(_gameManager.GameCodes.ToArray());

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _gameManager.GameCodes.CollectionChanged -= GameCodes_CollectionChanged;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
