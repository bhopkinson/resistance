using Resistance.Web.Hubs.RequestModels;

namespace Resistance.Web.Services
{
    public interface IGameConnectionIdStore
    {
        public string GetConnectionId(GamePlayer gamePlayer);

        public void StoreConnectionId(GamePlayer gamePlayer, string connectionId);
    }
}
