using Resistance.Web.Hubs.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers.DispatchModels
{
    public class DispatchContext
    {
        public List<GamePlayer> RecipientPlayers { get; set; }
    }
}
