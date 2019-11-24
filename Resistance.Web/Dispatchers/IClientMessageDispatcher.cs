using Resistance.Web.Dispatchers.DispatchModels;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public interface IClientMessageDispatcher
    {
        Task Publish(Lobby lobby);
        //Task Send();
        //Task SendToConnectionId(string connectionId);
    }
}