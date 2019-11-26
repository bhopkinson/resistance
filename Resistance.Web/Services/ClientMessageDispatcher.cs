using MessagePack;
using MessagePack.Resolvers;
using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;
using Resistance.Web.Dispatchers;
using Resistance.Web.Dispatchers.DispatchModels;
using System.IO;
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

        private async Task Publish(string topic, dynamic @object)
        {
            var bytes = GetBytes(@object);
            var message = BuildMqttApplicationMessage(topic, bytes);
            await PublishMessage(message);
        }

        private byte[] GetBytes(dynamic @object) =>
            MessagePackSerializer.Serialize(@object, ContractlessStandardResolver.Instance);

        private MqttApplicationMessage BuildMqttApplicationMessage(string topic, byte[] bytes) =>
            new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(bytes)
                .WithAtLeastOnceQoS()
                .WithRetainFlag()
                .Build();

        private async Task PublishMessage(MqttApplicationMessage message) =>
            await _mqttServer.PublishAsync(message);

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
