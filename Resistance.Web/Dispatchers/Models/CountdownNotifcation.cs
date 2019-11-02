using MediatR;

namespace Resistance.Web.Dispatchers.Models
{
    public class CountdownNotifcation : INotification
    {
        public bool Countdown { get; set; }
    }
}
