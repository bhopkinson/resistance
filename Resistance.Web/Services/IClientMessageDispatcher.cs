using Resistance.Web.Dispatchers.DispatchModels;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public interface IClientMessageDispatcher
    {
        Task PublishLobbyGameCodes(string[] gameCodes);
        //Task Send();
        //Task SendToConnectionId(string connectionId);
    }
}