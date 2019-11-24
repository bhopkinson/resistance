using System;

namespace Resistance.GameModels
{
    public class Player
    {
        public string Name { get; set; }
        public Character Character { get; set; }
        public bool IsReady { get; set; }
    }
}
