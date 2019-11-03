using MediatR;
using Resistance.Web.Hubs.ResponseModels;
using Resistance.Web.Models;

namespace Resistance.Web.Handlers.Requests
{
    public abstract class GameContext : IRequest<Response>
    {
        public string GameCode { get; set; }
        public string PlayerIntials { get; set; }
        public Game Game { get; set; }
    }
}
