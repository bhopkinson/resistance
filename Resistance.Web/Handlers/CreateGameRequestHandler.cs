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

        public CreateGameRequestHandler(IGameManager gameManager)
        {
            _gameManager = gameManager;
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
                response.Success = true;
            }

            return await Task.FromResult(response);
        }
    }
}
