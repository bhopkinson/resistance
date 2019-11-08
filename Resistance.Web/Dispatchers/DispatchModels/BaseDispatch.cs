using MediatR;

namespace Resistance.Web.Dispatchers.DispatchModels
{
    public class BaseDispatch : IRequest
    {
        public DispatchContext Context { get; set; }
    }
}
