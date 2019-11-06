using Resistance.GameModels.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.GameModels
{
    public class Investigation
    {
        public Player Investigator { get; set; }
        public Player Investigated { get; set; }

        public RevealedRole RevealedRole { get; set; }
    }
}
