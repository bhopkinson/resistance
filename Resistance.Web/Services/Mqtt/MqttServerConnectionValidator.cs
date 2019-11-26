using MQTTnet.Protocol;
using MQTTnet.Server;
using System.Threading.Tasks;

namespace Resistance.Web.Services.Mqtt
{
    public class MqttServerConnectionValidator : IMqttServerConnectionValidator
    {
        public async Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
        {
            switch (context.Username)
            {
                case "lobby":
                    context.ReasonCode = MqttConnectReasonCode.Success;
                    break;
                case "game":
                    context.ReasonCode = MqttConnectReasonCode.Success;
                    break;
                default:
                    context.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                    break;
            }

            await Task.CompletedTask;
        }
    }
}
