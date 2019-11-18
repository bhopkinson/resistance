using Resistance.Web.Hubs.RequestModels;
using Resistance.Web.Services;
using Resistance.Web.Commands;
using Resistance.Web.Events;
using Resistance.Web.MediationModels;
using Microsoft.AspNetCore.SignalR;
using SimpleMediator.Core;
using System.Threading.Tasks;
using System;

namespace Resistance.Web.Hubs
{
    public class LobbyHub : Hub<IGameHubClient>
    {
        private const string GameCode = "GameCode";
        private const string PlayerInitials = "PlayerInitials";

        private readonly IMediator _mediator;
        private readonly IGameConnectionIdStore _connectionManager;

        public LobbyHub(IMediator mediator, IGameConnectionIdStore connectionManager)
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

        public override async Task OnDisconnectedAsync(Exception ex) =>
            await Handle(new ClientDisconnectedEvent());

        private async Task Handle<TResult>(IMessage<TResult> message)
        {
            //var gameContext = GetGameContext();

            await _mediator.HandleAsync(
                message);

            //Context.Items[GameCode] = gameContext.GameCode;
            //Context.Items[PlayerInitials] = gameContext.PlayerIntials;
        }

        //private GameContext GetGameContext() =>
        //    new GameContext
        //    {
        //        ConnectionId = Context.ConnectionId,
        //        GameCode = (string)Context.Items[GameCode],
        //        PlayerIntials = (string)Context.Items[PlayerInitials]
        //    };
    }
}
