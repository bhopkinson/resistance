using MediatR;
using Resistance.Web.Handlers.Responses;

namespace Resistance.Web.Handlers.Requests
{
    public abstract class BaseRequest : IRequest<Response>
    {
        public GameContext Context { get; set; }
    }
}
