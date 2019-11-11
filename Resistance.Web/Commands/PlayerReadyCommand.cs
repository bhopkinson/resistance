using SimpleMediator.Commands;

namespace Resistance.Web.Commands
{
    public class PlayerReadyCommand : ICommand
    {
        public bool Ready { get; set; }
    }
}
