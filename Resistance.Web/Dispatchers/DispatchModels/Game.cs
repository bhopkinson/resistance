using System.Collections.Generic;

namespace Resistance.Web.Dispatchers.DispatchModels
{
    public class Game
    {
        public string Code { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
