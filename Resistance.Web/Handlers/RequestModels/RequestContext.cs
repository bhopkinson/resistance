using MediatR;
using Resistance.Web.Hubs.Models;
using Resistance.Web.Models;

namespace Resistance.Web.Handlers.RequestModels
{
    public abstract class RequestContext : IRequest<Response>
    {
        public string GameId { get; set; }
        public string PlayerIntials { get; set; }
        public GameOverview GameState { get; set; }
    }
}
