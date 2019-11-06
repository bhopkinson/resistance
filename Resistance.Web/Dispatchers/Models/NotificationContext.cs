﻿using MediatR;
using Resistance.Web.Hubs.RequestModels;
using System.Collections.Generic;

namespace Resistance.Web.Dispatchers.Models
{
    public class NotificationContext : IRequest
    {
        public List<GamePlayer> RecipientPlayers { get; set; }
    }
}
