using Resistance.Web.Models;
using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public interface ICharacterAssignment
    {
        void AssignRoles(ICollection<Player> players);
    }
}