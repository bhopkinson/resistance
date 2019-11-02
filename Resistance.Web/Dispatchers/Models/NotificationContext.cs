using MediatR;
using Resistance.Web.Hubs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers.Models
{
    public class NotificationContext : INotification
    {
        public List<GamePlayer> RecipientPlayers { get; set; }
    }
}
