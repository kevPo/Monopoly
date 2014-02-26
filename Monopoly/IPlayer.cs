using System;
namespace Monopoly
{
    public interface IPlayer
    {
        Int32 Location { get; set; }
        String Name { get; }
        void Rolled(Int32 rolled);
        void TakeTurn();
    }
}
