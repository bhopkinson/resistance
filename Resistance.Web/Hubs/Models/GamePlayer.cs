namespace Resistance.Web.Hubs.Models
{
    public class GamePlayer
    {
        public string GameId { get; set; }
        public string PlayerInitials { get; set; }

        public override bool Equals(object obj)
        {
            return PlayerInitials == PlayerInitials;
        }

        public override int GetHashCode()
        {
            return PlayerInitials.GetHashCode();
        }
    }
}
