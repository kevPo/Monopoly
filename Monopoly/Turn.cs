using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly
{
    public class Turn
    {
        private const Int32 maximumRolls = 3;
        private const Int32 maxTurnsInJail = 3;
        private const Int32 jailFine = 50;

        private IEnumerable<Location> locations;
        private IJailRoster jailRoster;
        private IPlayerService playerService;
        private IDice dice;
        private Int32 rollCount;
        private Int32 playerId;
        private Int32 currentLocationIndex;

        public Turn(IEnumerable<Location> locations, IJailRoster jailRoster, IPlayerService playerService, IDice dice)
        {
            this.locations = locations;
            this.jailRoster = jailRoster;
            this.playerService = playerService;
            this.dice = dice;
        }

        public void TakeFor(Int32 playerId)
        {
            rollCount = 0;
            currentLocationIndex = playerService.GetLocationIndexFor(playerId);
            this.playerId = playerId;

            if (jailRoster.IsInJail(playerId))
                TakeTurnForInmate();
            else
                TakeTurnForNormalPlayer();
        }

        private void TakeTurnForInmate()
        {
            dice.Roll();
            
            if (dice.RollWasDouble())
                SetJailedPlayerFreeAndMoveToDestination();
            else
                HandleNonDoubleRollForJailedPlayer();
        }

        private void SetJailedPlayerFreeAndMoveToDestination()
        {
            jailRoster.Remove(playerId);
            SendPlayerToDestination();
        }

        private void HandleNonDoubleRollForJailedPlayer()
        {
            var playerHasReachedMaxTurnsInJail = jailRoster.GetTurnsFor(playerId) + 1 == maxTurnsInJail;
            
            if (playerHasReachedMaxTurnsInJail)
                ChargePlayerFineAndMoveToDestination();
            else
                jailRoster.AddTurnFor(playerId);
        }

        private void ChargePlayerFineAndMoveToDestination()
        {
            CollectFineAndRemovePlayerFromJail();
            SendPlayerToDestination();
        }

        private void CollectFineAndRemovePlayerFromJail()
        {
            playerService.RemoveMoneyFrom(playerId, jailFine);
            jailRoster.Remove(playerId);
        }

        private void TakeTurnForNormalPlayer()
        {
            do
            {
                dice.Roll();
                rollCount++;
                MovePlayer();
            } while (dice.RollWasDouble() && rollCount < maximumRolls && !jailRoster.IsInJail(playerId));
        }

        private void MovePlayer()
        {
            if (rollCount == maximumRolls && dice.RollWasDouble())
                SendPlayerToJail();
            else
                SendPlayerToDestination();
        }

        private void SendPlayerToJail()
        {
            playerService.SetLocationIndexFor(playerId, 10);
            jailRoster.Add(playerId);
        }

        private void SendPlayerToDestination()
        {
            var roll = dice.GetCurrentRoll();

            for (var locationsPassed = 1; locationsPassed <= roll; locationsPassed++)
                SetPlayerOnNextLocation(roll, locationsPassed, GetCurrentLocationIndex());
        }

        private Location GetCurrentLocationIndex()
        {
            currentLocationIndex = (currentLocationIndex + 1) % locations.Count();
            var location = locations.First(l => l.Index == currentLocationIndex);
           
            return location;
        }

        private void SetPlayerOnNextLocation(Int32 roll, Int32 locationsPassed, Location location)
        {
            if (locationsPassed == roll)
                SetPlayerOnDestination(location);
            else
                location.PassedOverBy(playerId);
        }

        private void SetPlayerOnDestination(Location location)
        {
            playerService.SetLocationIndexFor(playerId, location.Index);
            location.LandedOnBy(playerId);
        }
    }
}
