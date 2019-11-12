using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Commands;
using Resistance.Web.MediationModels;
using Resistance.Web.MediationModels.Interfaces;
using SimpleMediator.Core;
using System.Threading.Tasks;

namespace Resistance.Web.Hubs
{
    public class LobbyHub : Hub<ILobbyClient>
    {
        private readonly IMediator _mediator;

        public LobbyHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task CreateGame() =>
            await Handle(new CreateGameCommand());

        private async Task Handle<TResult>(ILobbyMessage<TResult> message) =>
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
