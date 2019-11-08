using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Handlers.ResponseModels;
using Resistance.Web.Hubs.RequestModels;
using Resistance.Web.Services;
using System;
using System.Threading.Tasks;

namespace Resistance.Web.Hubs
{
    public class GameHub : Hub<IGameHubClient>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IGameConnectionIdStore _connectionManager;

        public GameHub(IMediator mediator, IMapper mapper, IGameConnectionIdStore connectionManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _connectionManager = connectionManager;
        }

        public async Task<Response> CreateGame()
        {
            return await _mediator.Send(new CreateGameRequest());
        }

        public async Task<Response> PlayerReady(bool ready)
        {
            var request = new PlayerReadyRequest { Ready = ready } ;
            return await HandleRequest(request);
        }

        public async Task JoinGame(GamePlayer player)
        {
            var request = new JoinGameRequest
            {
                Context = new GameContext
                {
                    PlayerIntials = player.PlayerInitials,
                    GameCode = player.GameId
                }
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

        //public async Task PlayMissionCard(PlayMissionCard missionCard)
        //{
        //    var request = new PlayMissionCardRequest();
        //    PopulateRequestContextFromHubContext(request);
        //    await _mediator.Send(request);
        //}

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await HandleRequest(new ClientDisconnectedRequest());
            await base.OnDisconnectedAsync(ex);
        }

        private async Task<Response> HandleRequest(BaseRequest request)
        {
            PopulateRequestContextFromHubContext(request.Context);
            return await _mediator.Send(request);
        }

        private void PopulateRequestContextFromHubContext(GameContext requestContext)
        {
            requestContext.GameCode = (string)Context.Items["GameId"];
            requestContext.PlayerIntials = (string)Context.Items["PlayerInitials"];
        }
    }
}
