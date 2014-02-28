using System;
namespace Monopoly
{
    public interface IPlayer
    {
        String Location { get; }
        String Name { get; }
        Int32 Balance { get; }
        void TakeTurn(Int32 rolled);
    }
}
