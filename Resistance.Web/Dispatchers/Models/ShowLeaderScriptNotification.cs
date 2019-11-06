using MediatR;

namespace Resistance.Web.Dispatchers.Models
{
    public class ShowLeaderScriptNotification : IRequest
    {
        public bool ShowScript { get; set; }
    }
}
