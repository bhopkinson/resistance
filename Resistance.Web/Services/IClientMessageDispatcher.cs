using Resistance.Web.Dispatchers.DispatchModels;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public interface IClientMessageDispatcher
    {
        Task Publish(Lobby lobby);
        //Task Send();
        //Task SendToConnectionId(string connectionId);
    }
}