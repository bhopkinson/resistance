using Resistance.GameModels;
using Resistance.GameModels.enums;

namespace Resistance.Web.Dispatchers.DispatchModels
{
    public class ShowCharacterNotification
    {
        public Role Role { get; set; }
        public Team Team { get; set; }
    }
}
