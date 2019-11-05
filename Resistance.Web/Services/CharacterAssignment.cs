using Resistance.Web.ExtentionMethods;
using Resistance.GameModel;
using Resistance.GameModel.enums;
using System.Collections.Generic;
using System.Linq;

namespace Resistance.Web.Services
{
    public class CharacterAssignment : ICharacterAssignment
    {
        public void AssignRoles(ICollection<Player> players)
        {
            var characters = GetCharacters(players.Count).ToList();

            var shuffledCharacters = characters.ShuffleList();

            int index = 0;
            foreach (var player in players)
            {
                player.Character = shuffledCharacters[index];
                index++;
            }
        }

        private IEnumerable<Character> GetCharacters(int count)
        {
            if (count < 5 || count > 11)
            {
                return new List<Character>() { new Character(Team.Spy, Role.Dummy) };
            }

            // Character create by default creates the hunters
            return count switch
            {
                5 => CharacterCreate(
                       RegularResistance: 1,
                       ChiefResistance: 1,
                       RegularSpy: 0,
                       ChiefSpy: 1),
                6 => CharacterCreate(
                        RegularResistance: 2,
                        ChiefResistance: 1,
                        RegularSpy: 0,
                        ChiefSpy: 1),
                7 => CharacterCreate(
                        RegularResistance: 2,
                        ChiefResistance: 1,
                        RegularSpy: 1,
                        ChiefSpy: 1),
                8 => CharacterCreate(
                        RegularResistance: 2,
                        ChiefResistance: 2,
                        RegularSpy: 1,
                        ChiefSpy: 1),
                9 => CharacterCreate(
                        RegularResistance: 3,
                        ChiefResistance: 2,
                        RegularSpy: 1,
                        ChiefSpy: 1),
                10 => CharacterCreate(
                        RegularResistance: 3,
                        ChiefResistance: 2,
                        RegularSpy: 1,
                        ChiefSpy: 2),
                11 => CharacterCreate(
                        RegularResistance: 1,
                        ChiefResistance: 2,
                        RegularSpy: 1,
                        ChiefSpy: 1),
                _ => new List<Character>(),
            };
        }

        private IEnumerable<Character> CharacterCreate(
            int RegularResistance,
            int ChiefResistance,
            int RegularSpy,
            int ChiefSpy)
        {
            var characters = new List<Character> {
                new Character(Team.Resistance, Role.Hunter),
                new Character(Team.Spy, Role.Hunter)
            };

            int n = 0;
            while (n < RegularResistance)
            {
                characters.Add(new Character(Team.Resistance, Role.Regular));
                n++;
            }

            n = 0;
            while (n < ChiefResistance)
            {
                characters.Add(new Character(Team.Resistance, Role.Chief));
                n++;
            }

            n = 0;
            while (n < RegularSpy)
            {
                characters.Add(new Character(Team.Spy, Role.Regular));
                n++;
            }

            n = 0;
            while (n < ChiefSpy)
            {
                characters.Add(new Character(Team.Spy, Role.Chief));
                n++;
            }

            return characters;
        }
    }
}
