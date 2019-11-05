using Resistance.Web.Dispatchers.Models;
using Resistance.GameModel;
using Resistance.GameModel.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Hubs
{
    public interface IGameHubClient
    {
        Task UpdatePlayersList(List<PlayerDetails> players);
        Task Countdown(bool countdown);
        Task GameBoardChange(List<GameBoardMission> missions, int voteCount, string leader);
        Task ShowCharacter(ShowCharacterNotification character);
        Task ShowLeaderScript(bool showScript);
    }
}
