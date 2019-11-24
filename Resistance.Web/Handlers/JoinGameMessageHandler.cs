using Resistance.Web.Dispatchers.DispatchModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Services;
using SimpleMediator.Commands;
using SimpleMediator.Core;
using Resistance.Web.Commands;
using Resistance.Web.MediationModels;
using Resistance.Web.Dispatchers;
using System;

namespace Resistance.Web.Handlers
{
    public class JoinGameMessageHandler : IMessageHandler<JoinGameMessage, Guid>
    {
        private readonly IGameManager _gameManager;
        private readonly IGameConnectionIdStore _gameConnectionIdStore;
        private readonly IClientMessageDispatcherFactory _clientMessageDispatcherFactory;
        private readonly IClientMessageDispatcher _clientMessageDispatcher;

        public JoinGameMessageHandler(
            IGameManager gameManager,
            IGameConnectionIdStore gameConnectionIdStore,
            IClientMessageDispatcherFactory clientMessageDispatcherFactory,
            IClientMessageDispatcher clientMessageDispatcher)
        {
            _gameManager = gameManager;
            _gameConnectionIdStore = gameConnectionIdStore;
            _clientMessageDispatcherFactory = clientMessageDispatcherFactory;
            _clientMessageDispatcher = clientMessageDispatcher;
        }

        public async Task<Guid> HandleAsync(JoinGameMessage message, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var game = _gameManager.GetGame(message.GameCode);

            var player = new GameModels.Player()
            {
                Name = message.PlayerName
            };

            var playerId = Guid.NewGuid();

            game.Players.TryAdd(playerId, player);

            return playerId;

            //_gameConnectionIdStore.StorePlayerConnectionIdForGame(command.GameCode, command.PlayerName, gameContext.ConnectionId);

            // TODO: refactor into own handler
            //var playerDetails = game.Players.Values
            //    .Select(p => new PlayerDetails { Intials = p.Name, Ready = p.IsReady })
            //    .ToList();

            //await _clientMessageDispatcher.Send();

            //await _clientMessageDispatcherFactory
            //    .CreateClientMessageDispatcher(x => x.UpdatePlayersList(playerDetails))
            //    .SendToAllGameClients(command.GameCode);
        }
    }
}
