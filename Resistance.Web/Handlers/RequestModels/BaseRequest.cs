using MediatR;
using Resistance.Web.Handlers.ResponseModels;

namespace Resistance.Web.Handlers.RequestModels
{
    public abstract class BaseRequest : IRequest<Response>
    {
        public GameContext Context { get; set; }
    }
}
