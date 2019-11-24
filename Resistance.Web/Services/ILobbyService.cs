using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public interface ILobbyService
    {
        string CreateGame();
        Task Publish();
    }
}