using System;
namespace Monopoly
{
    public interface IPlayer
    {
        Location Location { get; }
        String Name { get; }
        Int32 Balance { get; }
        void TakeTurn(Int32 rolled);
        void PayTax(Int32 tax);
        void ReceiveMoney(Int32 dollars);
        void GoDirectlyTo(String locationName);
        void LandedOn(Location location);
    }
}
