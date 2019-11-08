using AutoMapper;
using MediatR;
using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Handlers.ResponseModels;
using Resistance.GameModels.enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Handlers
{
    public class PlayerReadyRequestHandler : IRequestHandler<PlayerReadyRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PlayerReadyRequestHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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
            var playerDetails = context.Game.Players.Values.Select(p => new Dispatchers.Models.PlayerDetails { Intials = p.Initials, Ready = p.Ready }).ToList();
            var playersListNotification = new PlayersListNotification() { Players = playerDetails };
            await _mediator.Publish(playersListNotification);

            var allPlayersReady = context.Game.Players.All(o => o.Value.Ready);

            if (allPlayersReady && context.Game.Players.Count > 4 || context.Game.Players.Count == 1)
            {
                if (context.Game.CurrentState == GameState.GamePending)
                {
                    var startCountDown = new CountdownNotifcation() { Countdown = true };
                    await _mediator.Publish(startCountDown);
                }
                else
                {
                    var showScript = new ShowLeaderScriptNotification { ShowScript = true };
                    await _mediator.Publish(showScript);
                }

                return new Response(true);
            }

            return new Response(true);
        }
    }
}
