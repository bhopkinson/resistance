using Resistance.GameModels.enums;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Resistance.GameModels
{
    public class Game
    {
        public Game(string code)
        {
            Code = code;
            Players = new ConcurrentDictionary<string, Player>();
            SortedPlayers = new SortedSet<Player>();
            Missions = new List<Mission>();
            CurrentState = GameState.GamePending;
        }

        public string Code { get; set; }
        public ConcurrentDictionary<string, Player> Players { get; set; }
        public SortedSet<Player> SortedPlayers { get; set; }
        public IEnumerable<Mission> Missions { get; set; }
        public GameState CurrentState { get; set; }
    }
}
