using System;

namespace Monopoly.Locations
{
    public class CardDraw : Location
    {
        public CardDraw(Int32 index, String name) : base(index, name)
        { }

        public override void LandedOnBy(IPlayer player)
        { }
    }
}
