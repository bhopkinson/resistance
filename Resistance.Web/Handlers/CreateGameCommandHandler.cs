using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Commands;
using Resistance.Web.Hubs.Receipts;
using Resistance.Web.MediationModels;
using Resistance.Web.Services;
using SimpleMediator.Commands;
using SimpleMediator.Core;

namespace Resistance.Web.Handlers
{
    public class CreateGameCommandHandler : CommandHandler<CreateGameCommand>
    {
        private IGameManager _gameManager;
        private IClientMessageDispatcherFactory _clientMessageDispatcherFactory;

        public CreateGameCommandHandler(IGameManager gameManager, IClientMessageDispatcherFactory clientMessageDispatcherFactory)
        {
            _gameManager = gameManager;
            _clientMessageDispatcherFactory = clientMessageDispatcherFactory;
        }

        protected override async Task HandleCommandAsync(CreateGameCommand command, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var gameContext = mediationContext as GameContext;

            var code = _gameManager.CreateGame();

            var receipt = new CreateGameReceipt
            {
                GameCode = code
            };

            await _clientMessageDispatcherFactory
                    .CreateClientMessageDispatcher(x => x.CreateGameReceipt(receipt))
                    .SendToConnectionId(gameContext.ConnectionId);
        }
    }
}
