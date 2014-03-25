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
        private IPlayer player;
        private IDice dice;
        private Int32 rollCount;
        private Int32 currentLocationIndex;

        public Turn(IEnumerable<Location> locations, IJailRoster jailRoster, IPlayer player, IDice dice)
        {
            this.locations = locations;
            this.jailRoster = jailRoster;
            this.player = player;
            this.dice = dice;
            rollCount = 0;
        }

        public void Take()
        {
            currentLocationIndex = player.LocationIndex;

            if (jailRoster.IsInJail(player))
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
            jailRoster.Remove(player);
            SendPlayerToDestination();
        }

        private void HandleNonDoubleRollForJailedPlayer()
        {
            var playerHasReachedMaxTurnsInJail = jailRoster.GetTurnsFor(player) + 1 == maxTurnsInJail;
            
            if (playerHasReachedMaxTurnsInJail)
                ChargePlayerFineAndMoveToDestination();
            else
                jailRoster.AddTurnFor(player);
        }

        private void ChargePlayerFineAndMoveToDestination()
        {
            CollectFineAndRemovePlayerFromJail();
            SendPlayerToDestination();
        }

        private void CollectFineAndRemovePlayerFromJail()
        {
            player.RemoveMoney(jailFine);
            jailRoster.Remove(player);
        }

        private void TakeTurnForNormalPlayer()
        {
            do
            {
                dice.Roll();
                rollCount++;
                MovePlayer();
            } while (dice.RollWasDouble() && rollCount < maximumRolls && !jailRoster.IsInJail(player));
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
            player.LandedOn(10);
            jailRoster.Add(player);
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
                location.PassedOverBy(player);
        }

        private void SetPlayerOnDestination(Location location)
        {
            player.LandedOn(location.Index);
            location.LandedOnBy(player);
        }
    }
}
