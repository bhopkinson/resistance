﻿using Microsoft.AspNetCore.SignalR;
using MQTTnet;
using MQTTnet.Server;
using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Hubs;
using System;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public class LobbyClientMessageDispatcher : IClientMessageDispatcher
    {
        private readonly IMqttServer _mqttServer;
        private readonly IHubContext<LobbyHub, ILobbyHubClient> _lobbyHubContext;
        private readonly Func<ILobbyHubClient, Task> _clientMethod;

        public LobbyClientMessageDispatcher(
           IMqttServer mqttServer,
           IHubContext<LobbyHub, ILobbyHubClient> lobbyHubContext,
           Func<ILobbyHubClient, Task> clientMethod)
        {
            _mqttServer = mqttServer;
            _lobbyHubContext = lobbyHubContext;
            _clientMethod = clientMethod;
        }

        public Task Publish(Lobby lobby)
        {
            throw new NotImplementedException();
        }

        public async Task Send()
        {
                var message = new MqttApplicationMessageBuilder().WithTopic("lobby").WithPayload("test").Build();
                await _mqttServer.PublishAsync(message);
        }

        //public async Task Send() =>
        //    await _clientMethod(_lobbyHubContext.Clients.All);

        public async Task SendToConnectionId(string connectionId) =>
            await _clientMethod(_lobbyHubContext.Clients.Client(connectionId));
    }
}
