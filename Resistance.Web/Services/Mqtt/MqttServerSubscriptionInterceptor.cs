using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Services.Mqtt
{
    public class MqttServerSubscriptionInterceptor : IMqttServerSubscriptionInterceptor
    {
        public async Task InterceptSubscriptionAsync(MqttSubscriptionInterceptorContext context)
        {
            context.AcceptSubscription = true;
            await Task.CompletedTask;
        }
    }
}
