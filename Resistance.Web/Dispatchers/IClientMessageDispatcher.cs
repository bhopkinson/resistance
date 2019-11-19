using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public interface IClientMessageDispatcher
    {
        Task SendToConnectionId(string connectionId);
    }
}