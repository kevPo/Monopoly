using System;
using Monopoly.Locations;
namespace Monopoly.Board
{
    public interface IBoard
    {
        void AddLocation(Location location);
        void TakeTurnFor(IPlayer player);
    }
}
