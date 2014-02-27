using System;
namespace Monopoly
{
    public interface IPlayer
    {
        Int32 Location { get; }
        String Name { get; }
        void TakeTurn(Int32 rolled);
    }
}
