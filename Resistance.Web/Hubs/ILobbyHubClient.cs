using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Hubs.Receipts;

namespace Resistance.Web.Hubs
{
    public interface ILobbyHubClient
    {
        Task CreateGameReceipt(CreateGameReceipt receipt);
        Task UpdatePlayersList(List<PlayerDetails> players);
    }
}
