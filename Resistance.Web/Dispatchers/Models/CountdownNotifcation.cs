using MediatR;

namespace Resistance.Web.Dispatchers.Models
{
    public class CountdownNotifcation : IRequest
    {
        public bool Countdown { get; set; }
    }
}
