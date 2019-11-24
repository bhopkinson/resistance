using SimpleMediator.Core;
using System;

namespace Resistance.Web.Commands
{
    public class JoinGameMessage : IMessage<Guid>
    {
        public string GameCode { get; set; }
        public string PlayerName { get; set; }
    }
}
