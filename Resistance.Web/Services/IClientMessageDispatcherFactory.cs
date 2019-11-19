using Resistance.Web.Dispatchers;
using Resistance.Web.Hubs;
using System;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public interface IClientMessageDispatcherFactory
    {
        public GameClientMessageDispatcher CreateClientMessageDispatcher(Func<IGameHubClient, Task> clientMethod);
        public LobbyClientMessageDispatcher CreateClientMessageDispatcher(Func<ILobbyHubClient, Task> clientMethod);
    }
}
