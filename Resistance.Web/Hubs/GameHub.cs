using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Handlers.ResponseModels;
using Resistance.Web.Hubs.RequestModels;
using Resistance.Web.Services;
using System;
using System.Threading.Tasks;
using SimpleMediator.Core;
using Resistance.Web.Commands;

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

        public async Task CreateGame()
        {
            var gameContext = GetGameContext();
            await _mediator.HandleAsync(new CreateGameCommand(), gameContext);
        }

        public async Task JoinGame(GamePlayer player)
        {
            var gameContext = GetGameContext();
            await _mediator.HandleAsync(new JoinGameCommand(), gameContext);
        }

        public async Task<Response> PlayerReady(bool ready)
        {
            var request = new PlayerReadyCommand { Ready = ready };
            return await HandleRequest(request);
        }

        //public async Task StartGame()
        //{
        //    await _mediator.Send(new StartGameRequest());
        //}

        //public async Task PlayMissionCard(PlayMissionCard missionCard)
        //{
        //    var request = new PlayMissionCardRequest();
        //    PopulateRequestContextFromHubContext(request);
        //    await _mediator.Send(request);
        //}

        //public override async Task OnDisconnectedAsync(Exception ex)
        //{
        //    await HandleRequest(new ClientDisconnectedRequest());
        //    await base.OnDisconnectedAsync(ex);
        //}

        //private async Task<Response> HandleRequest(BaseRequest request)
        //{
        //    EnsureGameContext(request);
        //    PopulateRequestContextFromHubContext(request.Context);
        //    return await _mediator.Send(request);
        //}

        private void EnsureGameContext(BaseRequest request)
        {
            if (request.Context == null)
            {
                request.Context = new GameContext();
            }
        }

        private void PopulateRequestContextFromHubContext(GameContext requestContext)
        {
            requestContext.GameCode = (string)Context.Items["GameId"];
            requestContext.PlayerIntials = (string)Context.Items["PlayerInitials"];
        }

        private GameContext GetGameContext() => new GameContext
        {
            ConnectionId = Context.ConnectionId,
            GameCode = (string)Context.Items["GameCode"],
            PlayerIntials = (string)Context.Items["PlayerIntials"]
        };
    }
}
