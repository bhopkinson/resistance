using AutoMapper;
using AutoMapper.QueryableExtensions;
using Resistance.Web.Dispatchers.DispatchModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public class LobbyService : ILobbyService
    {
        private MapperConfiguration _mapperConfig;
        private IGameManager _gameManager;
        private IClientMessageDispatcherFactory _clientMessageDispatcherFactory;


        public LobbyService(
            MapperConfiguration mapperConfig,
            IGameManager gameManager,
            IClientMessageDispatcherFactory clientMessageDispatcherFactory)
        {
            _mapperConfig = mapperConfig;
            _gameManager = gameManager;
            _clientMessageDispatcherFactory = clientMessageDispatcherFactory;
        }

        public string CreateGame() =>
            _gameManager.CreateGame();

        public async Task SendLobbyUpdateToConnectedClients()
        {
            var lobby = new Lobby
            {
                Games = GetGames()
            };

            await _clientMessageDispatcherFactory
                    .CreateClientMessageDispatcher(x => x.UpdateLobby(lobby))
                    .Send();
        }

        private ICollection<Game> GetGames() =>
            _gameManager.GetAllGames()
                    .AsQueryable()
                    .OrderBy(g => g.Created)
                    .ProjectTo<Game>(_mapperConfig)
                    .ToList();
    }
}
