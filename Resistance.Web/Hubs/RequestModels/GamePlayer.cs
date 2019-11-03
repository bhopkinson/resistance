namespace Resistance.Web.Hubs.RequestModels
{
    public class GamePlayer
    {
        public string GameId { get; set; }
        public string PlayerInitials { get; set; }

        public override string ToString() => $"GameId: {GameId}, Initials: {PlayerInitials}";

        public override bool Equals(object obj)
        {
            if (!(obj is GamePlayer))
            {
                return false;
            }

            var other = (GamePlayer)obj;

            return GameId == other.GameId &&
                PlayerInitials == other.PlayerInitials;
        }

        public override int GetHashCode() => ToString().GetHashCode();
    }
}
