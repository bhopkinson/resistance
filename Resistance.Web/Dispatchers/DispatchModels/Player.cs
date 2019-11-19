using System;

namespace Resistance.Web.Dispatchers.DispatchModels
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsReady { get; set; }
    }
}
