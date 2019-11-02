using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Hubs.Models;
using Resistance.Web.Services;
using System.Threading.Tasks;

namespace Resistance.Web.Hubs
{
    public class GameHub : Hub<IGameHubClient>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ConnectionManager _connectionManager;

        public GameHub(IMediator mediator, IMapper mapper, ConnectionManager connectionManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _connectionManager = connectionManager;
        }

        public async Task Test(TestPlayerRequest testRequest)
        {
            await _mediator.Send(testRequest);
        }

        public async Task<Response> CreateGame()
        {
            return await _mediator.Send(new CreateGameRequest());
        }

        public async Task<Response> PlayerReady(bool ready)
        {
            var request = new PlayerReadyRequest { Ready = ready } ;
            PopulateRequestContextFromHubContext(request);
            return await _mediator.Send(request);
        }

        public async Task JoinGame(GamePlayer player)
        {
            var request = new JoinGameRequest
            {
                PlayerIntials = player.PlayerInitials,
                GameId = player.GameId
            };

            var response = await _mediator.Send(request);
            if (response.Success)
            {
                _connectionManager.StoreConnectionId(player, Context.ConnectionId);

                Context.Items["GameId"] = player.GameId;
                Context.Items["PlayerInitials"] = player.PlayerInitials;
            }
        }

        public async Task StartGame()
        {
            await _mediator.Send(new StartGameRequest());
        }

        public async Task PlayMissionCard(PlayMissionCard missionCard)
        {
            var request = new PlayMissionCardRequest();
            PopulateRequestContextFromHubContext(request);
            await _mediator.Send(request);
        }

        private void PopulateRequestContextFromHubContext(RequestContext requestContext)
        {
            requestContext.GameId = (string)Context.Items["GameId"];
            requestContext.PlayerIntials = (string)Context.Items["PlayerInitials"];
        }
    }
}
