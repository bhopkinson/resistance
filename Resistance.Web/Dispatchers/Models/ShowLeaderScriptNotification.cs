using MediatR;

namespace Resistance.Web.Dispatchers.Models
{
    public class ShowLeaderScriptNotification : INotification
    {
        public bool ShowScript { get; set; }
    }
}
