﻿using System;

namespace Resistance.GameModels
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Character Character { get; set; }
        public bool IsReady { get; set; }
    }
}
