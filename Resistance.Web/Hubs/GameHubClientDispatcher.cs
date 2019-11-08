using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Dispatchers.DispatchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Hubs
{
    public class GameHubClientDispatcher
    {
        private readonly IHubContext<GameHub, IGameHubClient> _gameHubContext;

        private Func<IGameHubClient, Task> _clientMethod;
        private object _message;

        public GameHubClientDispatcher(IHubContext<GameHub, IGameHubClient> gameHubContext)
        {
            _gameHubContext = gameHubContext;
            ClientMethod(x => x.Countdown(true));
        }

        public GameHubClientDispatcher ClientMethod(Func<IGameHubClient, Task> clientMethod)
        {
            _clientMethods = clientMethod;
            return this;
        }

        public async Task SendToAll(string gameCode)
        {
            return await _clientMethod(_gameHubContext.Clients.Client("test"));
        }

        public async Task SendToPlayer(string gameCode, string playerId)
        {

        }

        public async 

        public Task Countdown(bool countdown)
        {
            throw new NotImplementedException();
        }

        public Task GameBoardChange(List<GameBoardMission> missions, int voteCount, string leader)
        {
            throw new NotImplementedException();
        }

        public Task ShowCharacter(ShowCharacterNotification character)
        {
            throw new NotImplementedException();
        }

        public Task ShowLeaderScript(bool showScript)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlayersList(List<PlayerDetails> players)
        {
            throw new NotImplementedException();
        }
    }
}
