using MQTTnet.Protocol;
using MQTTnet.Server;
using System.Threading.Tasks;

namespace Resistance.Web.Services.Mqtt
{
    public class MqttServerConnectionValidator : IMqttServerConnectionValidator
    {
        private readonly IPlayerTokenService _playerTokenService;

        public MqttServerConnectionValidator(IPlayerTokenService playerTokenService)
        {
            _playerTokenService = playerTokenService;
        }

        public async Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
        {
            context.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;

            try
            {
                if (context.Username == "resistance"
                    && (string.IsNullOrEmpty(context.Password) || context.Password == "test"
                        || _playerTokenService.IsTokenValid(context.Password)))
                {
                    context.ReasonCode = MqttConnectReasonCode.Success;
                }
            }
            catch
            {
                // We currently don't worry what the exception was.
                // Perhaps add logging or a more detailed message.
            }
            
            await Task.CompletedTask;
        }
    }
}
