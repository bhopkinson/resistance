using Resistance.Web.Dispatchers.DispatchModels;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public interface IClientMessageDispatcher
    {
        Task PublishLobbyGameCodes(string[] gameCodes);
        Task PublishLobbyGamePlayers(string gameCode, Player[] players);
        //Task Send();
        //Task SendToConnectionId(string connectionId);
    }
}