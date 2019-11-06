using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Resistance.Web.Handlers.Requests;
using Resistance.Web.Handlers.Responses;
using Resistance.Web.Services;

namespace Resistance.Web.Handlers
{
    public class GameContextPreProcessor<T> : IRequestPreProcessor<T>
        where T : IRequest<Response>
    {
        IGameManager _gameManager;

        public GameContextPreProcessor(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public async Task Process(T request, CancellationToken cancellationToken)
        {
            if (request is BaseRequest)
            {
                var context = (request as BaseRequest).Context;
                var game = _gameManager.GetGame(context.GameCode);
                context.Game = game;
            }

            await Task.CompletedTask;
        }
    }
}
