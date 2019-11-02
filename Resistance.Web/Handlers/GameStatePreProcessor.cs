using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Services;

namespace Resistance.Web.Handlers
{
    public class RequestContextPreProcessor<IRequest> : IRequestPreProcessor<IRequest>
    {
        IGameStateManager _gameStateManager;

        public RequestContextPreProcessor(
            IGameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public async Task Process(IRequest request, CancellationToken cancellationToken)
        {
            var requestContext = request as RequestContext;
            var game = _gameStateManager.GetGame(requestContext.GameId);
            requestContext.GameState = game;

            await Task.CompletedTask;
        }
    }
}
