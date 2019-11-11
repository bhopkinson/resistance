using SimpleMediator.Commands;

namespace Resistance.Web.Handlers.RequestModels
{
    public class JoinGameCommand : ICommand
    {
        public string GameCode { get; set; }
        public string PlayerInitials { get; set; }
    }
}
