using System;
using Monopoly.Locations;
namespace Monopoly
{
    public interface IPlayer
    {
        Guid Id { get; }
        String Name { get; }
        Int32 LocationIndex { get; }
        void LandedOn(Int32 location);
        Int32 Balance { get; }
        void RemoveMoney(Int32 money);
        void ReceiveMoney(Int32 dollars);
    }
}
