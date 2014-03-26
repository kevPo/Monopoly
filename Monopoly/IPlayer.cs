using System;
using Monopoly.Locations;
namespace Monopoly
{
    public interface IPlayer
    {
        Int32 Id { get; }
        String Name { get; }
        Int32 LocationIndex { get; set; }
        Int32 Balance { get; }
        void RemoveMoney(Int32 money);
        void ReceiveMoney(Int32 dollars);
    }
}
