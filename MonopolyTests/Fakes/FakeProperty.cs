using System;
using Monopoly.Banker;
using Monopoly.Locations.Propertys;

namespace MonopolyTests.Fakes
{
    public class FakeProperty : Property
    {
        public FakeProperty(Int32 index, String name, Int32 cost, Int32 rent, IBanker banker) : 
            base(index, name, cost, rent, banker)
        { }

        protected override Int32 CalculateRent()
        {
            return 0;
        }

        public Int32 GetOwner()
        {
            return ownerId;
        }
    }
}
