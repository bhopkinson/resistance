using MQTTnet.Server;

namespace Resistance.Web.Services.Mqtt
{
    public class MqttServerOptions : MQTTnet.Server.MqttServerOptions
    {
        public MqttServerOptions(
            IMqttServerConnectionValidator mqttServerConnectionValidator,
            IMqttServerSubscriptionInterceptor mqttServerSubscriptionInterceptor)
        {
            ConnectionValidator = mqttServerConnectionValidator;
            DefaultEndpointOptions.IsEnabled = false;
            SubscriptionInterceptor = mqttServerSubscriptionInterceptor;
        }
    }
}
