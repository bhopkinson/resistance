using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Hubs.Receipts;
using System.Threading.Tasks;

namespace Resistance.Web.Hubs
{
    public interface ILobbyHubClient : IHubClient
    {
        Task CreateGameReceipt(CreateGameReceipt receipt);
        Task UpdateLobby(Lobby lobby);
    }
}
