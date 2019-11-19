using Resistance.Web.Hubs.RequestModels;
using Resistance.Web.Commands;
using Resistance.Web.Events;
using Resistance.Web.MediationModels;
using Microsoft.AspNetCore.SignalR;
using SimpleMediator.Core;
using System.Threading.Tasks;
using System;

namespace Resistance.Web.Hubs
{
    public class LobbyHub : Hub<ILobbyHubClient>
    {
        private readonly IMediator _mediator;

        public LobbyHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task CreateGame() =>
            await Handle(new CreateGameCommand());

        public async Task JoinGame(GamePlayer player) =>
            await Handle(new JoinGameCommand
            {
                GameCode = player.GameId,
                PlayerInitials = player.PlayerInitials
            });

        public override async Task OnDisconnectedAsync(Exception ex) =>
            await Handle(new ClientDisconnectedEvent());

        private async Task Handle<TResult>(IMessage<TResult> message) =>
            await _mediator.HandleAsync(
                message,
                GetLobbyContext());

        private LobbyContext GetLobbyContext() =>
            new LobbyContext
            {
                ConnectionId = Context.ConnectionId
            };
    }
}
