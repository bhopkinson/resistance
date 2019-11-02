using Resistance.Web.Models;
using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public interface IPlayerOrderInitialisation
    {
        SortedSet<Player> GetSortedPlayers(List<Player> players);
    }
}