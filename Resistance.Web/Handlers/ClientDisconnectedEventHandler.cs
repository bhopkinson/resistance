using Resistance.Web.Events;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Services;
using SimpleMediator.Core;
using SimpleMediator.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Handlers
{
    public class ClientDisconnectedEventHandler : EventHandler<ClientDisconnectedEvent>
    {
        private readonly IGameConnectionIdStore _gameConnectionIdStore;

        public ClientDisconnectedEventHandler(IGameConnectionIdStore gameConnectionIdStore)
        {
            _gameConnectionIdStore = gameConnectionIdStore;
        }

        protected override Task HandleEventAsync(ClientDisconnectedEvent @event, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var gameContext = mediationContext as GameContext;
            _gameConnectionIdStore.RemovePlayerConnectionIdForGame(gameContext.ConnectionId, gameContext.PlayerIntials);
            return Task.CompletedTask;
        }
    }
}
