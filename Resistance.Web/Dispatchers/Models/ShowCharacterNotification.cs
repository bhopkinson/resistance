using Resistance.GameModel;
using Resistance.GameModel.enums;

namespace Resistance.Web.Dispatchers.Models
{
    public class ShowCharacterNotification : NotificationContext
    {
        public Role Role { get; set; }
        public Team Team { get; set; }
    }
}
