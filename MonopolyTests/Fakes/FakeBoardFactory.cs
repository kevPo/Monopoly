using System;
using System.Collections.Generic;
using Monopoly;
using Monopoly.Board;
using Monopoly.Locations;

namespace MonopolyTests.Fakes
{
    public class FakeBoardFactory : BoardFactory
    {

        public FakeBoardFactory(IDice dice, IEnumerable<IPlayer> players, IJailRoster jailRoster) 
            : base (dice, players, jailRoster)
        {

        }

        protected override IEnumerable<Location> GetLocations()
        {
            return new Location[] { };
        }

        protected override Int32 LuxuryTaxEquation(Int32 balance)
        {
            return 0;
        }

        protected override Int32 IncomeTaxEquation(Int32 balance)
        {
            return 0;
        }
    }
}
