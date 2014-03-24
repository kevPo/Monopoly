using System;
using Monopoly;
using Monopoly.Locations.Propertys;

namespace MonopolyTests.Fakes
{
    public class FakeProperty : Property
    {
        public FakeProperty(Int32 index, String name, Int32 cost, Int32 rent) : base(index, name, cost, rent)
        { }

        protected override Int32 CalculateRent()
        {
            return 0;
        }

        public IPlayer GetOwner()
        {
            return Owner;
        }
    }
}
