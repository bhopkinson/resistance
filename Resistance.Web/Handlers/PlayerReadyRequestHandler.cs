using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Resistance.Web.Dispatchers.Models;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Hubs.Models;
using Resistance.Web.Models.enums;
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
            var player = request.GameState.Players
                .Where(o => o.Key == request.PlayerIntials)
                .SingleOrDefault()
                .Value;

            player.Ready = request.Ready;

            //var playerDetails = _mapper.ProjectTo<Dispatchers.Models.PlayerDetails>(request.GameState.Players.Values.AsQueryable()).ToList();
            var playerDetails = request.GameState.Players.Values.Select(p => new Dispatchers.Models.PlayerDetails { Intials = p.Initials, Ready = p.Ready }).ToList();
            var playersListNotification = new PlayersListNotification() { Players = playerDetails };
            await _mediator.Publish(playersListNotification);

            var allPlayersReady = request.GameState.Players.All(o => o.Value.Ready);

            if (allPlayersReady && request.GameState.Players.Count > 4 || request.GameState.Players.Count == 1)
            {
                if (request.GameState.CurrentState == GameState.GamePending)
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
