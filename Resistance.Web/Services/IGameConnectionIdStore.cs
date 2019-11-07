namespace Resistance.Web.Services
{
    public interface IGameConnectionIdStore
    {
        string GetConnectionId(string gameCode, string playerId);

        void StoreConnectionId(string gameCode, string connectionId);

        void StoreConnectionId(string gameCode, string playerId, string connectionId);

        void RemoveConnectionId(string gameCode, string playerId);
    }
}
