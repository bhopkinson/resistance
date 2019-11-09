using AutoMapper;
using MediatR;
using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Handlers.ResponseModels;
using Resistance.GameModels.enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Services;

namespace Resistance.Web.Handlers
{
    public class PlayerReadyRequestHandler : IRequestHandler<PlayerReadyRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IClientMessageDispatcherFactory _clientMessageDispatcherFactory;

        public PlayerReadyRequestHandler(
            IMediator mediator,
            IMapper mapper,
            IClientMessageDispatcherFactory clientMessageDispatcherFactory)
        {
            _mediator = mediator;
            _mapper = mapper;
            _clientMessageDispatcherFactory = clientMessageDispatcherFactory;
        }

        public async Task<Response> Handle(PlayerReadyRequest request, CancellationToken cancellationToken)
        {
            var context = request.Context;
            var player = context.Game.Players
                .Where(o => o.Key == context.PlayerIntials)
                .SingleOrDefault()
                .Value;

            player.Ready = request.Ready;

            //var playerDetails = _mapper.ProjectTo<Dispatchers.Models.PlayerDetails>(request.GameState.Players.Values.AsQueryable()).ToList();
            var playerDetails = context.Game.Players.Values.Select(p => new PlayerDetails { Intials = p.Initials, Ready = p.Ready }).ToList();
            await _clientMessageDispatcherFactory
                .CreateClientMessageDispatcher(x => x.UpdatePlayersList(playerDetails))
                .SendToAllGameClients(context.GameCode);

            var allPlayersReady = context.Game.Players.All(o => o.Value.Ready);

            if (allPlayersReady && context.Game.Players.Count > 4 || context.Game.Players.Count == 1)
            {
                if (context.Game.CurrentState == GameState.GamePending)
                {
                    await _clientMessageDispatcherFactory
                        .CreateClientMessageDispatcher(x => x.Countdown(true))
                        .SendToAllGameClients(context.GameCode);
                }
                else
                {
                    await _clientMessageDispatcherFactory
                        .CreateClientMessageDispatcher(x => x.ShowLeaderScript(true))
                        .SendToAllGameClients(context.GameCode);
                }

                return new Response(true);
            }

            return new Response(true);
        }
    }
}
