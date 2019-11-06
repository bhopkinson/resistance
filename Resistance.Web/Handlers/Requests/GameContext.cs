using Resistance.GameModels;

namespace Resistance.Web.Handlers.Requests
{
    public class GameContext
    {
        public string GameCode { get; set; }
        public string PlayerIntials { get; set; }
        public Game Game { get; set; }
    }
}
