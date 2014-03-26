using System;

namespace Monopoly.Locations
{
    public abstract class Location
    {
        public Int32 Index { get; private set; }
        public String Name { get; private set; }
        protected IPlayerService playerService;
        protected Int32 passOverSalary;

        public Location(Int32 index, String name, IPlayerService playerService)
        {
            Index = index;
            Name = name;
            this.playerService = playerService;
            passOverSalary = 0;
        }

        public void PassedOverBy(Int32 playerId)
        {
            if (passOverSalary > 0)
                playerService.AddMoneyTo(playerId, passOverSalary);
        }

        public abstract void LandedOnBy(Int32 playerId);
    }
}
