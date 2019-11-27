using SimpleMediator.Queries;
using System;

namespace Resistance.Web.Commands
{
    public class JoinGameMessage : IQuery<Guid>
    {
        public string GameCode { get; set; }
        public string PlayerName { get; set; }
    }
}
