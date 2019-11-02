using Resistance.Web.Models;
using Resistance.Web.Models.enums;

namespace Resistance.Web.Dispatchers.Models
{
    public class ShowCharacterNotification : NotificationContext
    {
        public Role Role { get; set; }
        public Team Team { get; set; }
    }
}
