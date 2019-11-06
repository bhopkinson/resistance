using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers.Models
{
    public class PlayersListNotification : IRequest
    {
        public List<PlayerDetails> Players { get; set; }
    }
}