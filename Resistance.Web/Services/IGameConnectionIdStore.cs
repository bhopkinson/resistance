using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public interface IGameConnectionIdStore
    {
        ICollection<string> GetConnectionIdsForGame(string gameCode);

        string GetPlayerConnectionIdForGame(string gameCode, string playerId);

        void StoreConnectionIdForGame(string gameCode, string connectionId);

        void StorePlayerConnectionIdForGame(string gameCode, string playerId, string connectionId);

        void RemovePlayerConnectionIdForGame(string gameCode, string playerId);
    }
}
