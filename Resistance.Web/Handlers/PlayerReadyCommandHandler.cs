using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.GameModels.enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Services;
using SimpleMediator.Commands;
using SimpleMediator.Core;
using Resistance.Web.Commands;
using Resistance.Web.MediationModels;

namespace Resistance.Web.Handlers
{
    public class PlayerReadyCommandHandler : CommandHandler<PlayerReadyCommand>
    {
        private readonly IClientMessageDispatcherFactory _clientMessageDispatcherFactory;

        public PlayerReadyCommandHandler(
            IClientMessageDispatcherFactory clientMessageDispatcherFactory)
        {
            _clientMessageDispatcherFactory = clientMessageDispatcherFactory;
        }

        protected override async Task HandleCommandAsync(PlayerReadyCommand command, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var gameContext = mediationContext as GameContext;
            var player = gameContext.Game.Players
                .Where(o => o.Key == gameContext.PlayerId)
                .SingleOrDefault()
                .Value;

            player.IsReady = command.Ready;

            //var playerDetails = _mapper.ProjectTo<Dispatchers.Models.PlayerDetails>(request.GameState.Players.Values.AsQueryable()).ToList();
            //var playerDetails = gameContext.Game.Players.Values.Select(p => new PlayerDetails { Intials = p.Name, Ready = p.IsReady }).ToList();
            //await _clientMessageDispatcherFactory
            //    .CreateClientMessageDispatcher(x => x.UpdatePlayersList(playerDetails))
            //    .SendToAllGameClients(gameContext.GameCode);

            //var allPlayersReady = gameContext.Game.Players.All(o => o.Value.IsReady);

            //if (allPlayersReady && gameContext.Game.Players.Count > 4 || gameContext.Game.Players.Count == 1)
            //{
            //    if (gameContext.Game.CurrentState == GameState.GamePending)
            //    {
            //        await _clientMessageDispatcherFactory
            //            .CreateClientMessageDispatcher(x => x.Countdown(true))
            //            .SendToAllGameClients(gameContext.GameCode);
            //    }
            //    else
            //    {
            //        await _clientMessageDispatcherFactory
            //            .CreateClientMessageDispatcher(x => x.ShowLeaderScript(true))
            //            .SendToAllGameClients(gameContext.GameCode);
            //    }
            //}
        }
    }
}
