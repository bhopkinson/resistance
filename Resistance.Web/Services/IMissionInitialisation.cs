using Resistance.Web.Models;
using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public interface IMissionInitialisation
    {
        IEnumerable<Mission> InitiliseMissions(int numberOfPlayers);
    }
}