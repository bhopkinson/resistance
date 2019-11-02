﻿using Resistance.Web.Models.enums;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Resistance.Web.Models
{
    public class GameOverview
    {
        public GameOverview(string gameId)
        {
            Id = gameId;
            Players = new ConcurrentDictionary<string, Player>();
            SortedPlayers = new SortedSet<Player>();
            Missions = new List<Mission>();
            CurrentState = GameState.GamePending;
        }

        public string Id { get; set; }
        public ConcurrentDictionary<string, Player> Players { get; set; }
        public SortedSet<Player> SortedPlayers { get; set; }
        public IEnumerable<Mission> Missions { get; set; }
        public GameState CurrentState { get; set; }
    }
}
