﻿using System;
namespace Monopoly.Locations
{
    public class Jail : Location
    {
        public Jail(Int32 index, String name) : base(index, name)
        { }

        public override void LandedOnBy(IPlayer player)
        {
        }
    }
}
