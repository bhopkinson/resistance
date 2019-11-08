using MediatR;
using Resistance.Web.Handlers.ResponseModels;

namespace Resistance.Web.Handlers.RequestModels
{
    public class CreateGameRequest : IRequest<CreateGameResponse>
    {
    }
}