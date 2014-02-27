using System;
namespace Monopoly
{
    public interface IPlayer
    {
        Location Location { get; }
        String Name { get; }
        void TakeTurn(Int32 rolled);
    }
}
