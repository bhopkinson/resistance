using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Hubs.Models
{
    public class PlayerDetails
    {
        public string Intials { get; set; }
        public string Colour { get; set; }
        public bool Ready { get; set; }
    }
}
