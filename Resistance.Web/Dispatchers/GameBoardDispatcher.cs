using MediatR;
using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Hubs;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public class GameBoardDispatcher : INotificationHandler<GameBoardNotification>
    {
        private readonly IHubContext<GameHub, IGameHubClient> _gameHubContext;

        public GameBoardDispatcher(IHubContext<GameHub, IGameHubClient> gameHubContext)
        {
            _gameHubContext = gameHubContext;
        }

        public async Task Handle(GameBoardNotification notification, CancellationToken cancellationToken)
        {
            await _gameHubContext.Clients.All.GameBoardChange(notification.Missions, notification.VoteCount, notification.Leader);
        }
    }
}
