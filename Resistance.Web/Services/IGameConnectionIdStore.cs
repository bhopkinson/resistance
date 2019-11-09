using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public interface IGameConnectionIdStore
    {
        ICollection<string> GetConnectionIdsForGame(string gameCode);

        string GetConnectionId(string gameCode, string playerId);

        void StoreConnectionId(string gameCode, string connectionId);

        void StoreConnectionId(string gameCode, string playerId, string connectionId);

        void RemoveConnectionId(string gameCode, string playerId);
    }
}
