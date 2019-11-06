using AutoMapper;
using MediatR;
using Resistance.Web.Dispatchers.Models;
using Resistance.Web.Handlers.Requests;
using Resistance.Web.Handlers.Responses;
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
            var player = request.Game.Players
                .Where(o => o.Key == request.PlayerIntials)
                .SingleOrDefault()
                .Value;

            player.Ready = request.Ready;

            //var playerDetails = _mapper.ProjectTo<Dispatchers.Models.PlayerDetails>(request.GameState.Players.Values.AsQueryable()).ToList();
            var playerDetails = request.Game.Players.Values.Select(p => new Dispatchers.Models.PlayerDetails { Intials = p.Initials, Ready = p.Ready }).ToList();
            var playersListNotification = new PlayersListNotification() { Players = playerDetails };
            await _mediator.Publish(playersListNotification);

            var allPlayersReady = request.Game.Players.All(o => o.Value.Ready);

            if (allPlayersReady && request.Game.Players.Count > 4 || request.Game.Players.Count == 1)
            {
                if (request.Game.CurrentState == GameState.GamePending)
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
