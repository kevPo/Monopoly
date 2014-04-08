using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Banker;
using Monopoly.Locations.Defaults;
using Monopoly.Locations.Propertys;

namespace Monopoly.Board
{
    public class GameBoard : IBoard
    {
        private const Int32 jailIndex = 10;
        private const Int32 passGoBonus = 200;

        public IEnumerable<Location> Locations { get; private set; }
        private IBanker banker;
        private IDictionary<Int32, Int32> playerLocations;
        private IEnumerable<Railroad> railroads;
        private IEnumerable<Utility> utilities;

        public GameBoard(IBanker banker)
        {
            this.banker = banker;
        }

        public void SetLocations(IEnumerable<Location> locations, IEnumerable<Railroad> railroads,
            IEnumerable<Utility> utilities)
        {
            Locations = AggregateAllLocations(locations, railroads, utilities);
            this.railroads = railroads;
            this.utilities = utilities;
            playerLocations = new Dictionary<Int32, Int32>();
        }

        private IEnumerable<Location> AggregateAllLocations(IEnumerable<Location> locations, 
            IEnumerable<Railroad> railroads, IEnumerable<Utility> utilities)
        {
            var allLocations = new List<Location>();
            allLocations.AddRange(locations);
            allLocations.AddRange(railroads);
            allLocations.AddRange(utilities);

            return allLocations;
        }

        public void SendPlayerDirectlyTo(Int32 playerId, Int32 locationIndex)
        {
            var destination = Locations.FirstOrDefault(l => l.Index == locationIndex);
            SetLocationIndexFor(playerId, locationIndex);
            destination.LandedOnBy(playerId);
        }

        private void SetLocationIndexFor(Int32 playerId, Int32 locationIndex)
        {
            playerLocations.Remove(playerId);
            playerLocations.Add(playerId, locationIndex);
        }

        public void MovePlayer(Int32 playerId, Int32 locationsToMove)
        {
            var currentLocation = GetLocationIndexFor(playerId);
            var nextLocation = (currentLocation + (Locations.Count() + locationsToMove)) % Locations.Count();
            
            SendPlayerDirectlyTo(playerId, nextLocation);
            AddBonusIfPlayerPassedGo(playerId, locationsToMove, currentLocation);
        }
       
        private void AddBonusIfPlayerPassedGo(Int32 playerId, Int32 locationsToMove, Int32 currentLocation)
        {
            var timesAroundBoard = 
                ((currentLocation + (Locations.Count() + locationsToMove)) / Locations.Count()) - 1;

            for (var i = 0; i < timesAroundBoard; i++)
                banker.PayMoneyTo(playerId, passGoBonus);
        }

        public void MovePlayerTo(Int32 playerId, Int32 destinationIndex)
        {
            var locationsToMove = GetNumberOfLocationsToMove(playerId, destinationIndex);
            MovePlayer(playerId, locationsToMove);
        }

        private Int32 GetNumberOfLocationsToMove(Int32 playerId, Int32 destinationIndex)
        {
            var currentLocationOfPlayer = GetLocationIndexFor(playerId);

            if (currentLocationOfPlayer < destinationIndex)
                return destinationIndex - currentLocationOfPlayer;
            else
                return Locations.Count() - Math.Abs((destinationIndex - currentLocationOfPlayer));
        }

        public void SendPlayerDirectlyToJail(Int32 playerId)
        {
            SendPlayerDirectlyTo(playerId, jailIndex);
        }

        public Int32 GetLocationIndexFor(Int32 playerId)
        {
            try
            {
                return playerLocations[playerId];
            }
            catch
            {
                SetLocationIndexFor(playerId, 0);
                return 0;
            }
        }

        private Property GetNearestPropertyInGroupFor(Int32 locationIndex, IEnumerable<Property> properties)
        {
            var firstPropertyIndex = properties.Select(r => r.Index).Min();
            var lastPropertyIndex = properties.Select(r => r.Index).Max();

            if (locationIndex >= lastPropertyIndex)
                return properties.FirstOrDefault(r => r.Index == firstPropertyIndex);
            else
                return properties.FirstOrDefault(r => r.Index > locationIndex);
        }

        public void SendPlayerToNearestUtility(Int32 playerId)
        {
            var nearestUtility = GetNearestUtilityFor(playerId);
            nearestUtility.LandedOnFromCardCommand(playerId);
            SetLocationIndexFor(playerId, nearestUtility.Index);
        }

        private Utility GetNearestUtilityFor(Int32 playerId)
        {
            return GetNearestPropertyInGroupFor(GetLocationIndexFor(playerId), utilities) as Utility;
        }

        public void SendPlayerToNearestRailroad(Int32 playerId)
        {
            var nearestRailroad = GetNearestRailroadFor(playerId);
            nearestRailroad.LandedOnFromCardCommand(playerId);
            SetLocationIndexFor(playerId, nearestRailroad.Index);
        }
       
        private Railroad GetNearestRailroadFor(Int32 playerId)
        {
            return GetNearestPropertyInGroupFor(GetLocationIndexFor(playerId), railroads) as Railroad;
        }
    }
}
