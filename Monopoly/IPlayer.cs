using System;
using Monopoly.Locations;
namespace Monopoly
{
    public interface IPlayer
    {
        Int32 LocationIndex { get; }
        String Name { get; }
        Int32 Balance { get; }
        void RemoveMoney(Int32 money);
        void ReceiveMoney(Int32 dollars);
        void LandedOn(Int32 location);
    }
}
