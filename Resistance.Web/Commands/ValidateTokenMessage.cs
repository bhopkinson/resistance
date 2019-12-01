using SimpleMediator.Queries;

namespace Resistance.Web.Commands
{
    public class ValidateTokenMessage : IQuery<bool>
    {
        public string Token { get; set; }
    }
}
