using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Commands;
using Resistance.Web.Services;
using SimpleMediator.Core;
using SimpleMediator.Queries;

namespace Resistance.Web.Handlers
{
    public class CreateGameMessageHandler
        : QueryHandler<CreateGameMessage, string>
    {
        private readonly ILobbyService _lobbyService;

        public CreateGameMessageHandler(
            ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }

        protected override async Task<string> HandleQueryAsync(
            CreateGameMessage message,
            IMediationContext mediationContext,
            CancellationToken cancellationToken)
        {
            var code = _lobbyService.CreateGame();
            
            await _lobbyService.Publish();

            return code;
        }
    }
}
