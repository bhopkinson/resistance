using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Services;
using SimpleMediator.Core;
using Resistance.Web.Commands;
using System;
using DynamicData;
using SimpleMediator.Queries;

namespace Resistance.Web.Handlers
{
    public class JoinGameMessageHandler : QueryHandler<JoinGameMessage, Guid>
    {
        private readonly IGameManager _gameManager;
        private readonly IGameConnectionIdStore _gameConnectionIdStore;
        private readonly IClientMessageDispatcher _clientMessageDispatcher;

        public JoinGameMessageHandler(
            IGameManager gameManager,
            IGameConnectionIdStore gameConnectionIdStore,
            IClientMessageDispatcher clientMessageDispatcher)
        {
            _gameManager = gameManager;
            _gameConnectionIdStore = gameConnectionIdStore;
            _clientMessageDispatcher = clientMessageDispatcher;
        }

        protected override async Task<Guid> HandleQueryAsync(JoinGameMessage message, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var game = _gameManager.GetGame(message.GameCode);

            var player = new GameModels.Player()
            {
                Name = message.PlayerName
            };

            var playerId = Guid.NewGuid();

            game.PlayersLobby.AddOrUpdate(player);

            return await Task.FromResult(playerId);

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
