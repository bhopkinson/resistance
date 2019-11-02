using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Hubs.Models;
using Resistance.Web.Services;

namespace Resistance.Web.Handlers
{
    public class CreateGameRequestHandler : IRequestHandler<CreateGameRequest, Response>
    {
        private IGameStateManager _gameStateManager;

        public CreateGameRequestHandler(IGameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public async Task<Response> Handle(CreateGameRequest request, CancellationToken cancellationToken)
        {
            if (_gameStateManager.CreateGame() != null)
            {
                return await Task.FromResult(new Response(true));
            }
            else
            {
                return await Task.FromResult(new Response(false));
            }
        }
    }
}
