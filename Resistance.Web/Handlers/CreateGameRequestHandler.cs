using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Resistance.Web.Handlers.RequestModels;
using Resistance.Web.Handlers.ResponseModels;
using Resistance.Web.Services;

namespace Resistance.Web.Handlers
{
    public class CreateGameRequestHandler : IRequestHandler<CreateGameRequest, CreateGameResponse>
    {
        private IGameManager _gameManager;
        private IGameConnectionIdStore _gameConnectionIdStore;

        public CreateGameRequestHandler(IGameManager gameManager, IGameConnectionIdStore gameConnectionIdStore)
        {
            _gameManager = gameManager;
            _gameConnectionIdStore = gameConnectionIdStore;
        }

        public async Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
        {
            var code = _gameManager.CreateGame();

            var response = new CreateGameResponse
            {
                GameCode = code
            };

            if (string.IsNullOrEmpty(code))
            {
                response.ErrorMessage = "Unable to create game.";
            }
            else
            {
                _gameConnectionIdStore.StoreConnectionIdForGame(code, request.ConnectionId);
                response.Success = true;
            }

            return await Task.FromResult(response);
        }
    }
}
