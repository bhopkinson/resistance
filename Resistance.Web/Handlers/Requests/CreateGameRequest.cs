using MediatR;
using Resistance.Web.Handlers.Responses;

namespace Resistance.Web.Handlers.Requests
{
    public class CreateGameRequest : IRequest<CreateGameResponse>
    {
    }
}