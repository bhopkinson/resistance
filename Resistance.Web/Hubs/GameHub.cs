using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Hubs.RequestModels;
using Resistance.Web.Services;
using System;
using System.Threading.Tasks;
using SimpleMediator.Core;
using Resistance.Web.Commands;
using Resistance.Web.Events;
using Resistance.Web.MediationModels;

namespace Resistance.Web.Hubs
{
    public class GameHub : Hub<IGameHubClient>
    {
        private const string GameCode = "GameCode";
        private const string PlayerInitials = "PlayerInitials";

        private readonly IMediator _mediator;
        private readonly IGameConnectionIdStore _connectionManager;

        public GameHub(IMediator mediator, IGameConnectionIdStore connectionManager)
        {
            _mediator = mediator;
            _connectionManager = connectionManager;
        }

        public async Task CreateGame() =>
            await Handle(new CreateGameMessage());

        public async Task JoinGame(GamePlayer player) =>
            await Handle(new JoinGameMessage
            {
                GameCode = player.GameId,
                PlayerName = player.PlayerInitials
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

        private async Task Handle<TResult>(IMessage<TResult> message)
        {
            var gameContext = GetGameContext();

            await _mediator.HandleAsync(
                message,
                gameContext);

            Context.Items[GameCode] = gameContext.GameCode;
            Context.Items[PlayerInitials] = gameContext.PlayerIntials;
        }

        private GameContext GetGameContext() =>
            new GameContext
            {
                ConnectionId = Context.ConnectionId,
                GameCode = (string)Context.Items[GameCode],
                PlayerIntials = (string)Context.Items[PlayerInitials]
            };
    }
}
