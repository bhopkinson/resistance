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
    public class JoinGameMessageHandler : QueryHandler<JoinGameMessage, string>
    {
        private readonly IGameManager _gameManager;
        private readonly IGameConnectionIdStore _gameConnectionIdStore;
        private readonly IClientMessageDispatcher _clientMessageDispatcher;
        private readonly IPlayerTokenService _playerTokenService;

        public JoinGameMessageHandler(
            IGameManager gameManager,
            IGameConnectionIdStore gameConnectionIdStore,
            IClientMessageDispatcher clientMessageDispatcher,
            IPlayerTokenService playerTokenService)
        {
            _gameManager = gameManager;
            _gameConnectionIdStore = gameConnectionIdStore;
            _clientMessageDispatcher = clientMessageDispatcher;
            _playerTokenService = playerTokenService;
        }

        protected override async Task<string> HandleQueryAsync(JoinGameMessage message, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var game = _gameManager.GetGame(message.GameCode);

            var player = new GameModels.Player()
            {
                Id = Guid.NewGuid(),
                Name = message.PlayerName
            };

            game.PlayersLobby.AddOrUpdate(player);

            var token = _playerTokenService.GenerateToken(game.Code, player.Id);

            return await Task.FromResult(token);

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
