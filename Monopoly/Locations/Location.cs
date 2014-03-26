using System;

namespace Monopoly.Locations
{
    public abstract class Location
    {
        public Int32 Index { get; private set; }
        public String Name { get; private set; }
        protected IPlayerRepository playerRepository;
        protected Int32 passOverSalary;

        public Location(Int32 index, String name, IPlayerRepository playerRepository)
        {
            Index = index;
            Name = name;
            this.playerRepository = playerRepository;
            passOverSalary = 0;
        }

        public void PassedOverBy(Int32 playerId)
        {
            if (passOverSalary > 0)
                playerRepository.AddMoneyTo(playerId, passOverSalary);
        }

        public abstract void LandedOnBy(Int32 playerId);
    }
}
