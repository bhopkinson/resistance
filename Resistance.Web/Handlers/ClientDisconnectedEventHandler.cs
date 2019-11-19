using Resistance.Web.Events;
using Resistance.Web.MediationModels;
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
            // TODO: Add back in:
            // _gameConnectionIdStore.RemovePlayerConnectionIdForGame(gameContext.GameCode, gameContext.ConnectionId);
            return Task.CompletedTask;
        }
    }
}
