using Resistance.GameModel;
using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public interface IMissionInitialisation
    {
        IEnumerable<Mission> InitiliseMissions(int numberOfPlayers);
    }
}