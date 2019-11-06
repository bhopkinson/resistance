using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Resistance.Web.Dispatchers.Models;
using Resistance.Web.Handlers.Requests;
using Resistance.Web.Handlers.Responses;
using Resistance.Web.Hubs.RequestModels;
using Resistance.GameModels.enums;
using Resistance.Web.Services;

namespace Resistance.Web.Handlers
{
    public class StartGameRequestHandler : IRequestHandler<StartGameRequest, Response>
    {
        private readonly ICharacterAssignment _characterAssignment;
        private readonly IMissionInitialisation _missionInitialisation;
        private readonly IPlayerOrderInitialisation _playerOrderInitialisation;
        private readonly IMediator _mediator;

        public StartGameRequestHandler(
            ICharacterAssignment characterAssignment,
            IMissionInitialisation missionInitialisation,
            IPlayerOrderInitialisation playerOrderInitialisation,
            IMediator mediator)
        {
            _characterAssignment = characterAssignment;
            _missionInitialisation = missionInitialisation;
            _playerOrderInitialisation = playerOrderInitialisation;
            _mediator = mediator;
        }
        public async Task<Response> Handle(StartGameRequest request, CancellationToken cancellationToken)
        {
            var context = request.Context;
            var gameReady = context.Game.Players.All(o => o.Value.Ready);

            if (!gameReady)
            {
                return new Response(false, "Not all players are ready.");
            }

            context.Game.CurrentState = GameState.Started;
            foreach (var playerReset in context.Game.Players)
            {
                playerReset.Value.Ready = false;
            }

            var players = context.Game.Players.Values.ToList();

            _characterAssignment.AssignRoles(players);

            foreach (var player in players)
            {
                var playerCharacterNotification = new ShowCharacterNotification()
                {
                    Role = player.Character.Role,
                    Team = player.Character.Team,
                    RecipientPlayers = new List<GamePlayer>()
                    {
                        new GamePlayer
                        {
                            PlayerInitials = player.Initials
                        }
                    }
                };

                await _mediator.Publish(playerCharacterNotification);
            }

            context.Game.SortedPlayers = _playerOrderInitialisation.GetSortedPlayers(players);
            context.Game.Missions = _missionInitialisation.InitiliseMissions(players.Count);

            var firstMission = context.Game.Missions.Where(o => o.Number == 1).SingleOrDefault();
            firstMission.Team.Leader = context.Game.SortedPlayers.First();

            //TODO broadcast mission update

            return new Response(true);
        }
    }
}
