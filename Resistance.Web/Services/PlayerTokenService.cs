using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public class PlayerTokenService : IPlayerTokenService
    {
        private readonly IGameManager _gameManager;

        public PlayerTokenService(
            IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public string GenerateToken(string gameCode, Guid playerId)
        {
            var bytes = GetKeyBytes(gameCode);
            var securityKey = new SymmetricSecurityKey(bytes);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);
            var payload = new JwtPayload
            {
                { "game_code", gameCode },
                { "player_id", playerId }
            };
            var securityToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(securityToken);
            return tokenString;
        }

        private byte[] GetKeyBytes(string gameCode) =>
            _gameManager.GetGame(gameCode).Key;
    }
}
