using MediatR;
using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Hubs;
using Resistance.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public class CountdownDispatcher : BaseDispatcher, INotificationHandler<CountdownNotifcation>
    {
        public CountdownDispatcher(IHubContext<GameHub, IGameHubClient> gameHubContext, IGameConnectionIdStore connectionManger)
            : base(gameHubContext, connectionManger)
        {
        }

        public async Task Handle(CountdownNotifcation notification, CancellationToken cancellationToken)
        {
            await _gameHubContext.Clients.All.Countdown(notification.Countdown);
        }
    }
}
