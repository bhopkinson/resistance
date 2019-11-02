using AutoMapper;
using MediatR;
using Resistance.Web.Dispatchers.Models;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Hubs.Models;
using Resistance.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Handlers
{
    public class JoinGameRequestHandler : IRequestHandler<JoinGameRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public JoinGameRequestHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Response> Handle(JoinGameRequest request, CancellationToken cancellationToken)
        {
            var game = request.GameState;

            var player = new Player()
            {
                Initials = request.PlayerIntials
            };

            var success = game.Players.TryAdd(player.Initials, player);
            var message = success ? null : "Player with initials already exists.";
            var response = new Response(success, message);

            // TODO: refactor into own handler
            var playerDetails = request.GameState.Players.Values
                .Select(p => new Dispatchers.Models.PlayerDetails { Intials = p.Initials, Ready = p.Ready })
                .ToList();
            var playersListNotification = new PlayersListNotification() { Players = playerDetails };
            await _mediator.Publish(playersListNotification);

            return response;
        }
    }
}
