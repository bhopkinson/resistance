using SimpleMediator.Commands;

namespace Resistance.Web.Handlers.RequestModels
{
    public class PlayerReadyCommand : ICommand
    {
        public bool Ready { get; set; }
    }
}
