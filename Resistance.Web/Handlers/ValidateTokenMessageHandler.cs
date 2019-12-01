using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Services;
using SimpleMediator.Core;
using Resistance.Web.Commands;
using SimpleMediator.Queries;

namespace Resistance.Web.Handlers
{
    public class ValidateTokenMessageHandler : QueryHandler<ValidateTokenMessage, bool>
    {
        private readonly IPlayerTokenService _playerTokenService;

        public ValidateTokenMessageHandler(
            IPlayerTokenService playerTokenService)
        {
            _playerTokenService = playerTokenService;
        }

        protected override async Task<bool> HandleQueryAsync(ValidateTokenMessage message, IMediationContext mediationContext, CancellationToken cancellationToken) =>
            await Task.FromResult(_playerTokenService.IsTokenValid(message.Token));
    }
}
