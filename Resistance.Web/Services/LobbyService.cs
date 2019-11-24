using AutoMapper;
using AutoMapper.QueryableExtensions;
using Resistance.Web.Dispatchers;
using Resistance.Web.Dispatchers.DispatchModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public class LobbyService : ILobbyService
    {
        private IMapper _mapper;
        private IGameManager _gameManager;
        private IClientMessageDispatcher _clientMessageDispatcher;

        public LobbyService(
            IMapper mapper,
            IGameManager gameManager,
            IClientMessageDispatcher clientMessageDispatcher)
        {
            _mapper = mapper;
            _gameManager = gameManager;
            _clientMessageDispatcher = clientMessageDispatcher;
        }

        public string CreateGame() =>
            _gameManager.CreateGame();

        public async Task Publish() =>
            await _clientMessageDispatcher.Publish(new Lobby
            {
                Games = GetGames()
            });

        private ICollection<Game> GetGames() =>
            _mapper.ProjectTo<Game>(
                _gameManager.GetAllGames()
                .AsQueryable()
                .OrderBy(g => g.Created))
            .ToList();
    }
}
