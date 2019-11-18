﻿using Resistance.GameModels;
using SimpleMediator.Core;

namespace Resistance.Web.MediationModels
{
    public class GameContext : IMediationContext
    {
        public string ConnectionId { get; set; }
        public string GameCode { get; set; }
        public string PlayerIntials { get; set; }
        public Game Game { get; set; }
    }
}