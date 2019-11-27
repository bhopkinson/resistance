using AutoMapper;
using DynamicData;
using Resistance.GameModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Resistance.Web.Services
{
    public class LobbyService : ILobbyService, IDisposable
    {
        private readonly Dictionary<string, IDisposable> _playersUpdatedSubscriptions = new Dictionary<string, IDisposable>();

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

        public string CreateGame()
        {
            var code = _gameManager.CreateGame();

            void publishLobbyGamePlayers(Player player) =>
                _clientMessageDispatcher.PublishLobbyGamePlayers(
                        code,
                        _mapper.Map<Dispatchers.DispatchModels.Player[]>(
                            _gameManager.GetGame(code).PlayersLobby.Items));

            var playersUpdatedSubsription = _gameManager.GetGame(code).PlayersLobby
                .Connect()
                .OnItemAdded(publishLobbyGamePlayers)
                .OnItemRemoved(publishLobbyGamePlayers)
                .WhenAnyPropertyChanged(nameof(Player.IsReady))
                .Subscribe(publishLobbyGamePlayers);

            _playersUpdatedSubscriptions.Add(code, playersUpdatedSubsription);

            return code;
        }

        private async void GameCodes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) =>
            await _clientMessageDispatcher.PublishLobbyGameCodes(_gameManager.GameCodes.ToArray());

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _gameManager.GameCodes.CollectionChanged -= GameCodes_CollectionChanged;
                    _playersUpdatedSubscriptions.Values.ToList().ForEach(v => v.Dispose());
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
