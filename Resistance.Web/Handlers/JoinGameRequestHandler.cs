using AutoMapper;
using MediatR;
using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Handlers.ResponseModels;
using Resistance.GameModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Services;

namespace Resistance.Web.Handlers
{
    public class JoinGameRequestHandler : IRequestHandler<JoinGameRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IGameConnectionIdStore _gameConnectionIdStore;
        private readonly IClientMessageDispatcherFactory _clientMessageDispatcherFactory;

        public JoinGameRequestHandler(
            IMediator mediator,
            IMapper mapper,
            IGameConnectionIdStore gameConnectionIdStore,
            IClientMessageDispatcherFactory clientMessageDispatcherFactory)
        {
            _mediator = mediator;
            _mapper = mapper;
            _gameConnectionIdStore = gameConnectionIdStore;
            _clientMessageDispatcherFactory = clientMessageDispatcherFactory;
        }

        public async Task<Response> Handle(JoinGameRequest request, CancellationToken cancellationToken)
        {
            var context = request.Context;
            var game = context.Game;

            var player = new Player()
            {
                Initials = context.PlayerIntials
            };

            var success = game.Players.TryAdd(player.Initials, player);
            var message = success ? null : "Player with initials already exists.";
            var response = new Response(success, message);

            _gameConnectionIdStore.StorePlayerConnectionIdForGame(context.GameCode, context.PlayerIntials, request.ConnectionId);
            
            // TODO: refactor into own handler
            var playerDetails = context.Game.Players.Values
                .Select(p => new PlayerDetails { Intials = p.Initials, Ready = p.Ready })
                .ToList();

            await _clientMessageDispatcherFactory
                .CreateClientMessageDispatcher(x => x.UpdatePlayersList(playerDetails))
                .SendToAllGameClients(context.GameCode);

            return response;
        }
    }
}
