using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.GameModels;
using Resistance.GameModels.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resistance.Web.Hubs.Receipts;

namespace Resistance.Web.Hubs
{
    public interface IGameHubClient
    {
        Task CreateGameReceipt(CreateGameReceipt receipt);
        Task UpdatePlayersList(List<PlayerDetails> players);
        Task Countdown(bool countdown);
        Task GameBoardChange(List<GameBoardMission> missions, int voteCount, string leader);
        Task ShowCharacter(ShowCharacterNotification character);
        Task ShowLeaderScript(bool showScript);
    }
}
