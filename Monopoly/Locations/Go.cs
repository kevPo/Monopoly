using System;
namespace Monopoly.Locations
{
    public class Go : Location
    {
        public Go(Int32 index, String name) : base(index, name)
        {
            this.passOverSalary = 200;
        }

        public override void LandedOnBy(IPlayer player)
        {
            player.ReceiveMoney(passOverSalary);
        }
    }
}
