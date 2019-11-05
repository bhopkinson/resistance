using Resistance.GameModels.enums;

namespace Resistance.GameModels
{
    public class Character
    {
        public Character(Team team, Role role)
        {
            Team = team;
            Role = role;
        }

        public Team Team { get; set; }
        public Role Role { get; set; }
    }
}
