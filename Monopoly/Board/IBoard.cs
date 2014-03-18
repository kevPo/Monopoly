using System;
using Monopoly.Locations;
namespace Monopoly.Board
{
    public interface IBoard
    {
        Location GetStartingLocation();
        void InitializeBanker(IBanker banker);
        void AddLocation(Location location);
        void TakeTurnFor(IPlayer player);
    }
}
