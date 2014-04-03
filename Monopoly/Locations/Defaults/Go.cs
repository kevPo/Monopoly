using System;
using Monopoly.Banker;
namespace Monopoly.Locations.Defaults
{
    public class Go : Location
    {
        public Go(Int32 index, String name, IBanker banker) 
            : base(index, name, banker)
        {
            this.passOverSalary = 200;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            banker.PayMoneyTo(playerId, passOverSalary);
        }
    }
}
