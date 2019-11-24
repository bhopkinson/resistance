using MQTTnet.Protocol;
using MQTTnet.Server;
using Resistance.Web.Dispatchers;
using Resistance.Web.Dispatchers.DispatchModels;
using System.Text.Json;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public class ClientMessageDispatcher : IClientMessageDispatcher
    {
        private readonly IMqttServer _mqttServer;

        public ClientMessageDispatcher(IMqttServer mqttServer)
        {
            _mqttServer = mqttServer;
        }

        public async Task Publish(Lobby lobby) =>
            await Publish(Topics.LOBBY, lobby);

        private async Task Publish(string topic, object messageObject) =>
            await _mqttServer.PublishAsync(
                topic,
                JsonSerializer.Serialize(messageObject),
                MqttQualityOfServiceLevel.AtLeastOnce,
                retain: true);

        //public async Task SendToPlayerInGame(string gameCode, string playerId) =>
        //    await SendToConnectionId(
        //        _gameConnectionIdStore.GetPlayerConnectionIdForGame(gameCode, playerId));

        //public async Task SendToPlayersInGame(string gameCode, ICollection<string> playerIds) =>
        //    await SendToConnecionIds(playerIds
        //        .Select(playerId => _gameConnectionIdStore.GetPlayerConnectionIdForGame(gameCode, playerId))
        //        .ToArray());

        //public async Task SendToAllGameClients(string gameCode) =>
        //    await SendToConnecionIds(
        //        _gameConnectionIdStore.GetConnectionIdsForGame(gameCode));

        //public async Task SendToConnectionId(string connectionId) =>
        //    await _clientMethod(_gameHubContext.Clients.Client(connectionId));

        //private async Task SendToConnecionIds(ICollection<string> connectionIds) =>
        //    await Task.WhenAll(
        //        connectionIds.Select(
        //            connectionId => SendToConnectionId(connectionId)));

        //public Task Send()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
