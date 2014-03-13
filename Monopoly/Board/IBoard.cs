using System;
using Monopoly.Locations;
using Monopoly.PropertyGroups;
namespace Monopoly.Board
{
    public interface IBoard
    {
        Location GetStartingLocation();
        void InitializeBanker(IBanker banker);
        void AddLocation(Location location);
        void AddPropertyGroup(PropertyGroup propertyGroup);
        void TakeTurnFor(IPlayer player);
    }
}
