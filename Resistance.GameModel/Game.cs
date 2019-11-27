using DynamicData;
using Resistance.GameModels.enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Resistance.GameModels
{
    public class Game
    {
        public Game(string code)
        {
            Code = code;
            Created = DateTimeOffset.Now;
            SortedPlayers = new SortedSet<Player>();
            Missions = new List<Mission>();
            CurrentState = GameState.GamePending;
        }

        public string Code { get; set; }
        public DateTimeOffset Created { get; set; }

        public SourceCache<Player, Guid> PlayersLobby { get; } = new SourceCache<Player, Guid>(p => p.Id);

        public SortedSet<Player> SortedPlayers { get; set; }
        public IEnumerable<Mission> Missions { get; set; }
        public GameState CurrentState { get; set; }
    }
}
