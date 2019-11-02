using Resistance.Web.ExtentionMethods;
using Resistance.Web.Models;
using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public class PlayerOrderInitialisation : IPlayerOrderInitialisation
    {
        public SortedSet<Player> GetSortedPlayers(List<Player> players)
        {
            var sortedPlayers = players.ShuffleList();

            var setPlayers = new SortedSet<Player>();

            foreach(var player in sortedPlayers)
            {
                setPlayers.Add(player);
            }

            return setPlayers;
        }
    }
}
