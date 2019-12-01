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
        private const string GAME_CODE = "game_code";
        private const string PLAYER_ID = "player_id";
        
        private readonly IGameManager _gameManager;

        public PlayerTokenService(
            IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public string GenerateToken(string gameCode, Guid playerId)
        {
            var bytes = GetKeyBytesForGame(gameCode);
            var securityKey = new SymmetricSecurityKey(bytes);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);
            var payload = new JwtPayload
            {
                { GAME_CODE, gameCode },
                { PLAYER_ID, playerId }
            };
            var securityToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(securityToken);
            return tokenString;
        }

        public bool IsTokenValid(string tokenString)
        {
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadJwtToken(tokenString);
            var claims = securityToken.Claims.ToDictionary(c => c.Type, c => c.Value);
            var gameCode = claims[GAME_CODE];
            var game = _gameManager.GetGame(gameCode);
            var securityKey = new SymmetricSecurityKey(game.Key);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateLifetime = false,
                ValidateTokenReplay = false,
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = securityKey
            };

            var principle = handler.ValidateToken(tokenString, tokenValidationParameters, out _);
            var playerId = Guid.Parse(securityToken.Claims.First(c => c.Type == PLAYER_ID).Value);
            if (game.PlayersLobby.Keys.Contains(playerId))
            {
                return true;
            }

            return false;
        }

        private byte[] GetKeyBytesForGame(string gameCode) =>
            _gameManager.GetGame(gameCode).Key;
    }
}
