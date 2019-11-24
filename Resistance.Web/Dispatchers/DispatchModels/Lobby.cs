using System.Collections.Generic;

namespace Resistance.Web.Dispatchers.DispatchModels
{
    public class Lobby
    {
        public ICollection<Game> Games { get; set; }
    }
}
