using MediatR;

namespace Resistance.Web.Dispatchers.DispatchModels
{
    public class CountdownNotifcation : IRequest
    {
        public bool Countdown { get; set; }
    }
}