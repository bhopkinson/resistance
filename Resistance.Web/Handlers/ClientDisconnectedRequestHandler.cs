﻿using MediatR;
using Resistance.Web.Handlers.Requests;
using Resistance.Web.Handlers.Responses;
using Resistance.Web.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Handlers
{
    public class ClientDisconnectedRequestHandler : IRequestHandler<ClientDisconnectedRequest, Response>
    {
        private readonly IGameConnectionIdStore _gameConnectionIdStore;

        public ClientDisconnectedRequestHandler(IGameConnectionIdStore gameConnectionIdStore)
        {
            _gameConnectionIdStore = gameConnectionIdStore;
        }

        public Task<Response> Handle(ClientDisconnectedRequest request, CancellationToken cancellationToken)
        {
            var context = request.Context;
            _gameConnectionIdStore.RemoveConnectionId(context.GameCode, context.PlayerIntials);
            return Task.FromResult(new Response());
        }
    }
}
