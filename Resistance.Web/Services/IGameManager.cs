using DynamicData.Binding;
using Resistance.GameModels;
using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public interface IGameManager
    {
        IObservableCollection<string> GameCodes { get; }

        public string CreateGame();
        public Game GetGame(string gameId);
        public ICollection<Game> GetAllGames();
    }
}
