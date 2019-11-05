﻿using MediatR;
using Resistance.Web.Handlers.Responses;
using Resistance.Web.Hubs.ResponseModels;
using Resistance.GameModel;

namespace Resistance.Web.Handlers.Requests
{
    public abstract class GameContext : IRequest<Response>
    {
        public string GameCode { get; set; }
        public string PlayerIntials { get; set; }
        public Game Game { get; set; }
    }
}
