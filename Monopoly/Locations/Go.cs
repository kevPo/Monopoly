using System;
namespace Monopoly.Locations
{
    public class Go : Location
    {
        public Go(Int32 index, String name, IPlayerRepository playerRepository) 
            : base(index, name, playerRepository)
        {
            this.passOverSalary = 200;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            playerRepository.AddMoneyTo(playerId, passOverSalary);
        }
    }
}
