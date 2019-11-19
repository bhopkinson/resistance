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
        private ILobbyService _lobbyService;
        private IClientMessageDispatcherFactory _clientMessageDispatcherFactory;

        public CreateGameCommandHandler(ILobbyService lobbyService, IClientMessageDispatcherFactory clientMessageDispatcherFactory)
        {
            _lobbyService = lobbyService;
            _clientMessageDispatcherFactory = clientMessageDispatcherFactory;
        }

        protected override async Task HandleCommandAsync(CreateGameCommand command, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var lobbyContext = mediationContext as LobbyContext;

            var code = _lobbyService.CreateGame();

            var receipt = new CreateGameReceipt
            {
                GameCode = code
            };

            await _clientMessageDispatcherFactory
                    .CreateClientMessageDispatcher(x => x.CreateGameReceipt(receipt))
                    .SendToConnectionId(lobbyContext.ConnectionId);

            await _lobbyService.SendLobbyUpdateToConnectedClients();
        }
    }
}
