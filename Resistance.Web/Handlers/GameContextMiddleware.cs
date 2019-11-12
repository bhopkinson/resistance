using Resistance.Web.Services;
using SimpleMediator.Core;
using SimpleMediator.Middleware;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Handlers
{
    public class GameContextMiddleware<TMessage, TResponse> : IMiddleware<TMessage, TResponse> where TMessage : IMessage<TResponse>
    {
        IGameManager _gameManager;

        public GameContextMiddleware(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public async Task<TResponse> RunAsync(TMessage message, IMediationContext mediationContext, CancellationToken cancellationToken, HandleMessageDelegate<TMessage, TResponse> next)
        {
            var gameContext = mediationContext as GameContext;
            if (gameContext != null)
            {
                gameContext.Game = gameContext.GameCode != null ? _gameManager.GetGame(gameContext.GameCode) : null;
            }

            return await next.Invoke(message, mediationContext, cancellationToken);
        }
    }
}
