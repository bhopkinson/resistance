using MediatR;

namespace Resistance.Web.Dispatchers.DispatchModels
{
    public class ShowLeaderScriptNotification : IRequest
    {
        public bool ShowScript { get; set; }
    }
}
