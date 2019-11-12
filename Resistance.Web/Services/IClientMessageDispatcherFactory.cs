using Resistance.Web.Hubs;
using System;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public interface IClientMessageDispatcherFactory
    {
        public IClientMessageDispatcher CreateClientMessageDispatcher(Func<IGameHubClient, Task> clientMethod);
    }
}
