using Resistance.Web.Dispatchers;
using Resistance.Web.Hubs;
using System;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public interface IClientMessageDispatcherFactory
    {
        public ClientMessageDispatcher CreateClientMessageDispatcher(Func<IGameHubClient, Task> clientMethod);
    }
}
