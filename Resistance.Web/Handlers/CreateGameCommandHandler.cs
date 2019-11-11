using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Commands;
using Resistance.Web.Services;
using SimpleMediator.Commands;
using SimpleMediator.Core;

namespace Resistance.Web.Handlers
{
    public class CreateGameCommandHandler : CommandHandler<CreateGameCommand>
    {
        private IGameManager _gameManager;

        public CreateGameCommandHandler(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        protected async override Task HandleCommandAsync(CreateGameCommand command, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var code = _gameManager.CreateGame();
            await Task.CompletedTask;
        }
    }
}
