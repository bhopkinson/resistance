using Resistance.Web.Dispatchers.DispatchModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Services;
using SimpleMediator.Commands;
using SimpleMediator.Core;
using Resistance.Web.Commands;
using Resistance.Web.MediationModels;

namespace Resistance.Web.Handlers
{
    public class JoinGameCommandHandler : CommandHandler<JoinGameCommand>
    {
        private readonly IGameManager _gameManager;
        private readonly IGameConnectionIdStore _gameConnectionIdStore;
        private readonly IClientMessageDispatcherFactory _clientMessageDispatcherFactory;

        public JoinGameCommandHandler(
            IGameManager gameManager,
            IGameConnectionIdStore gameConnectionIdStore,
            IClientMessageDispatcherFactory clientMessageDispatcherFactory)
        {
            _gameManager = gameManager;
            _gameConnectionIdStore = gameConnectionIdStore;
            _clientMessageDispatcherFactory = clientMessageDispatcherFactory;
        }

        protected override async Task HandleCommandAsync(JoinGameCommand command, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var gameContext = mediationContext as GameContext;
            var game = _gameManager.GetGame(command.GameCode);

            var player = new GameModels.Player()
            {
                Name = command.PlayerInitials
            };

            game.Players.TryAdd(player.Name, player);

            _gameConnectionIdStore.StorePlayerConnectionIdForGame(command.GameCode, command.PlayerInitials, gameContext.ConnectionId);

            gameContext.GameCode = command.GameCode;
            gameContext.PlayerIntials = command.PlayerInitials;

            // TODO: refactor into own handler
            var playerDetails = game.Players.Values
                .Select(p => new PlayerDetails { Intials = p.Name, Ready = p.IsReady })
                .ToList();

            await _clientMessageDispatcherFactory
                .CreateClientMessageDispatcher(x => x.UpdatePlayersList(playerDetails))
                .SendToAllGameClients(command.GameCode);
        }
    }
}
