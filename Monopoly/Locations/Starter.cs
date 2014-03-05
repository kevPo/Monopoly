using System;
namespace Monopoly.Locations
{
    public class Starter : Location
    {
        public Starter() : base("Go")
        {
            this.passOverSalary = 200;
        }

        public override void LandedOnBy(IPlayer player)
        {
            player.ReceiveMoney(passOverSalary);
        }
    }
}
