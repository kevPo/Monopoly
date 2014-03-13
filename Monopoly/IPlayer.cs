using System;
using Monopoly.Locations;
namespace Monopoly
{
    public interface IPlayer
    {
        Location Location { get; }
        String Name { get; }
        Int32 Balance { get; }
        void RemoveMoney(Int32 money);
        void ReceiveMoney(Int32 dollars);
        void GoDirectlyTo(Location location);
        void LandedOn(Location location);
    }
}
