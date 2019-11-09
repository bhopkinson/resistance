using Resistance.Web.Hubs;
using System;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public interface IClientMessageDispatcherFactory
    {
        public IClientMessageDispatcher CreateClientMessageDispatcher(Func<IGameHubClient, Task> clientMethod);
    }
}
