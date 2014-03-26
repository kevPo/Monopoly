using System;
using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations;
using Monopoly.TraditionalMonopoly;

namespace MonopolyTests.Fakes
{
    public class FakeTraditionalBoardFactory : TraditionalBoardFactory
    {
        public FakeTraditionalBoardFactory(IDice dice, IPlayerRepository playerRepository, TraditionalJailRoster jailRoster)
            : base(dice, playerRepository, jailRoster)
        { }

        public Int32 GetIncomeTaxResult(Int32 balance)
        {
            return IncomeTaxEquation(balance);
        }

        public Int32 GetLuxuryTaxResult(Int32 balance)
        {
            return LuxuryTaxEquation(balance);
        }

        public IEnumerable<Location> GetTraditionalLocations()
        {
            return GetLocations();
        }
    }
}
