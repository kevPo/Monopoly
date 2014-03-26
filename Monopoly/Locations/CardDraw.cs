using System;

namespace Monopoly.Locations
{
    public class CardDraw : Location
    {
        public CardDraw(Int32 index, String name, IPlayerService playerService)
            : base(index, name, playerService)
        { }

        public override void LandedOnBy(Int32 playerId)
        { }
    }
}
