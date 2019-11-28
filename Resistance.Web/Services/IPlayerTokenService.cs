using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public interface IPlayerTokenService
    {
        string GenerateToken(string gameCode, Guid playerId);
    }
}
