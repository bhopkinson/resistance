using MediatR;
using Resistance.Web.Hubs.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Handlers
{
    public class TestRequestHandler : IRequestHandler<TestPlayerRequest, Response>
    {
        public Task<Response> Handle(TestPlayerRequest request, CancellationToken cancellationToken)
        {
            var response = new Response(
                true,
                $"You are {request.PlayerIntials} with game {request.GameId}."
            );

            return Task.FromResult(response);
        }
    }
}
