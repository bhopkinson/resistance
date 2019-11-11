using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.GameModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Services;
using SimpleMediator.Commands;
using SimpleMediator.Core;
using Resistance.Web.Commands;

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
            var game = _gameManager.GetGame(gameContext.GameCode);

            var player = new Player()
            {
                Initials = command.PlayerInitials
            };

            game.Players.TryAdd(player.Initials, player);

            _gameConnectionIdStore.StorePlayerConnectionIdForGame(command.GameCode, command.PlayerInitials, gameContext.ConnectionId);

            // TODO: refactor into own handler
            var playerDetails = gameContext.Game.Players.Values
                .Select(p => new PlayerDetails { Intials = p.Initials, Ready = p.Ready })
                .ToList();

            await _clientMessageDispatcherFactory
                .CreateClientMessageDispatcher(x => x.UpdatePlayersList(playerDetails))
                .SendToAllGameClients(gameContext.GameCode);
        }
    }
}
