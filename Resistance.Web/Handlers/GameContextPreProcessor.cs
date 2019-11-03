using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Resistance.Web.Handlers.Requests;
using Resistance.Web.Services;

namespace Resistance.Web.Handlers
{
    public class GameContextPreProcessor<T> : IRequestPreProcessor<T>
        where T : GameContext
    {
        IGameManager _gameManager;

        public GameContextPreProcessor(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public async Task Process(T context, CancellationToken cancellationToken)
        {
            var game = _gameManager.GetGame(context.GameCode);
            context.Game = game;

            await Task.CompletedTask;
        }
    }
}
