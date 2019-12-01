﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resistance.Web.Commands;
using SimpleMediator.Core;

namespace Resistance.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<string> Create() =>
            await _mediator.HandleAsync(new CreateGameMessage());

        [HttpPost]
        [Route("{gameCode}/join")]
        public async Task<string> Join(string gameCode, [FromBody] string playerName) =>
            await _mediator.HandleAsync(new JoinGameMessage
            {
                GameCode = gameCode,
                PlayerName = playerName
            });

        [HttpPost]
        [Route("validate-token")]
        public async Task ValidateToken([FromBody] string token) =>
            await _mediator.HandleAsync(new ValidateTokenMessage
            {
                Token = token
            });
    }
}