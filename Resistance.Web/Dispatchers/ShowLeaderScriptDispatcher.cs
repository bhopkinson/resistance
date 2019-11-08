using MediatR;
using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Hubs;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public class ShowLeaderScriptDispatcher : INotificationHandler<ShowLeaderScriptNotification>
    {
        private readonly IHubContext<GameHub, IGameHubClient> _gameHubContext;

        public ShowLeaderScriptDispatcher(IHubContext<GameHub, IGameHubClient> gameHubContext)
        {
            _gameHubContext = gameHubContext;
        }

        public async Task Handle(ShowLeaderScriptNotification notification, CancellationToken cancellationToken)
        {
            await _gameHubContext.Clients.All.ShowLeaderScript(notification.ShowScript);
        }
    }
}
