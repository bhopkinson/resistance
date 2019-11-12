using SimpleMediator.Commands;

namespace Resistance.Web.Commands
{
    public class JoinGameCommand : ICommand
    {
        public string GameCode { get; set; }
        public string PlayerInitials { get; set; }
    }
}
