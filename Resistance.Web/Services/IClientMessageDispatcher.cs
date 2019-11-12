using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public interface IClientMessageDispatcher
    {
        Task SendToPlayerInGame(string gameCode, string playerId);

        Task SendToPlayersInGame(string gameCode, ICollection<string> playerIds);

        Task SendToAllGameClients(string gameCode);

        Task SendToConnectionId(string connectionId);
    }
}