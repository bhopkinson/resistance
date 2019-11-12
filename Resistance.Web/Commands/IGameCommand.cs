using Resistance.Web.MediationModels.Interfaces;
using SimpleMediator.Core;

namespace Resistance.Web.Commands
{
    interface IGameCommand : IGameMessage<Unit>
    {
    }
}
