using MediatR;
using Resistance.Web.Handlers.Responses;

namespace Resistance.Web.Handlers.Requests
{
    // TODO: This should really inherit from IRequest<CreateGameResponse> however the
    // handler is not resolving correctly.
    public class CreateGameRequest : GameContext
    {
    }
}