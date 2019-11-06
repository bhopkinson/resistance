using MediatR;
using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Dispatchers.Models;
using Resistance.Web.Hubs;
using Resistance.Web.Services;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public class ShowCharacterDispatcher : BaseDispatcher, INotificationHandler<ShowCharacterNotification>
    {
        public ShowCharacterDispatcher(IHubContext<GameHub, IGameHubClient> gameHubContext, IGameConnectionIdStore connectionManger)
            : base(gameHubContext, connectionManger)
        {
        }

        public Task Handle(ShowCharacterNotification notification, CancellationToken cancellationToken)
        {
            var connectionIds = GetConnectionIds(notification as NotificationContext);

            return _gameHubContext.Clients.Clients(connectionIds.ToList()).ShowCharacter(notification);
        }
    }
}
