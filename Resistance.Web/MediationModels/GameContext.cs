using Resistance.GameModels;
using SimpleMediator.Core;
using System;

namespace Resistance.Web.MediationModels
{
    public class GameContext : IMediationContext
    {
        public string ConnectionId { get; set; }
        public string GameCode { get; set; }
        public Guid PlayerId { get; set; }
        public string PlayerIntials { get; set; }
        public Game Game { get; set; }
    }
}
