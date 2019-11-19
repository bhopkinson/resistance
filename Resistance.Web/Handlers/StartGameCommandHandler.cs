using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.GameModels.enums;
using Resistance.Web.Services;
using SimpleMediator.Commands;
using Resistance.Web.Commands;
using SimpleMediator.Core;
using Resistance.Web.MediationModels;

namespace Resistance.Web.Handlers
{
    public class StartGameCommandHandler : CommandHandler<StartGameCommand>
    {
        private readonly ICharacterAssignment _characterAssignment;
        private readonly IMissionInitialisation _missionInitialisation;
        private readonly IPlayerOrderInitialisation _playerOrderInitialisation;
        private readonly IClientMessageDispatcherFactory _clientMessageDispatcherFactory;

        public StartGameCommandHandler(
            ICharacterAssignment characterAssignment,
            IMissionInitialisation missionInitialisation,
            IPlayerOrderInitialisation playerOrderInitialisation,
            IClientMessageDispatcherFactory clientMessageDispatcherFactory)
        {
            _characterAssignment = characterAssignment;
            _missionInitialisation = missionInitialisation;
            _playerOrderInitialisation = playerOrderInitialisation;
            _clientMessageDispatcherFactory = clientMessageDispatcherFactory;
        }

        protected override async Task HandleCommandAsync(StartGameCommand command, IMediationContext mediationContext, CancellationToken cancellationToken)
        {
            var gameContext = mediationContext as GameContext;
            var gameReady = gameContext.Game.Players.All(o => o.Value.IsReady);

            // TODO: Add validation

            gameContext.Game.CurrentState = GameState.Started;
            foreach (var playerReset in gameContext.Game.Players)
            {
                playerReset.Value.IsReady = false;
            }

            var players = gameContext.Game.Players.Values.ToList();

            _characterAssignment.AssignRoles(players);

            foreach (var player in players)
            {
                var playerCharacterNotification = new ShowCharacterNotification()
                {
                    Role = player.Character.Role,
                    Team = player.Character.Team
                };

                await _clientMessageDispatcherFactory
                    .CreateClientMessageDispatcher(x => x.ShowCharacter(playerCharacterNotification))
                    .SendToPlayerInGame(gameContext.GameCode, player.Name);
            }

            gameContext.Game.SortedPlayers = _playerOrderInitialisation.GetSortedPlayers(players);
            gameContext.Game.Missions = _missionInitialisation.InitiliseMissions(players.Count);

            var firstMission = gameContext.Game.Missions.Where(o => o.Number == 1).SingleOrDefault();
            firstMission.Team.Leader = gameContext.Game.SortedPlayers.First();

            //TODO broadcast mission update
        }
    }
}
