using System;
namespace Monopoly.Locations
{
    public class Go : Location
    {
        public Go(Int32 index, String name, IPlayerService playerService) 
            : base(index, name, playerService)
        {
            this.passOverSalary = 200;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            playerService.AddMoneyTo(playerId, passOverSalary);
        }
    }
}
