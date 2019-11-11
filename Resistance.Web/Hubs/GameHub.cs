using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Hubs.RequestModels;
using Resistance.Web.Services;
using System;
using System.Threading.Tasks;
using SimpleMediator.Core;
using Resistance.Web.Commands;
using Resistance.Web.Events;
using Resistance.Web.Handlers;

namespace Resistance.Web.Hubs
{
    public class GameHub : Hub<IGameHubClient>
    {
        private readonly IMediator _mediator;
        private readonly IGameConnectionIdStore _connectionManager;

        public GameHub(IMediator mediator, IGameConnectionIdStore connectionManager)
        {
            _mediator = mediator;
            _connectionManager = connectionManager;
        }

        public async Task CreateGame() =>
            await Handle(new CreateGameCommand());

        public async Task JoinGame(GamePlayer player) =>
            await Handle(new JoinGameCommand
            {
                GameCode = player.GameId,
                PlayerInitials = player.PlayerInitials
            });

        public async Task PlayerReady(bool ready) =>
            await Handle(new PlayerReadyCommand
            {
                Ready = ready
            });

        public async Task StartGame() =>
            await Handle(new StartGameCommand());

        public override async Task OnDisconnectedAsync(Exception ex) =>
            await Handle(new ClientDisconnectedEvent());

        private async Task Handle<TResult>(IMessage<TResult> message) =>
            await _mediator.HandleAsync(
                message,
                GetGameContext());

        private GameContext GetGameContext() =>
            new GameContext
            {
                ConnectionId = Context.ConnectionId,
                GameCode = (string)Context.Items["GameCode"],
                PlayerIntials = (string)Context.Items["PlayerIntials"]
            };
    }
}
