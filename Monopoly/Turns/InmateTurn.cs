using System;
using System.Collections.Generic;
using Monopoly.Locations;

namespace Monopoly.Turns
{
    public class InmateTurn : Turn
    {
        private const Int32 jailFine = 50;
        private const Int32 maxTurnsInJail = 3;

		public InmateTurn(Int32 playerId, IDice dice, IJailRoster jailRoster,
						  IPlayerService playerService, IEnumerable<Location> locations)
			: base (playerId, dice, jailRoster, playerService, locations)
        { }

        public override void Take()
        {
            dice.Roll();

            if (dice.RollWasDouble())
                SetJailedPlayerFreeAndMoveToDestination();
            else
                HandleNonDoubleRollForJailedPlayer();
        }

        private void HandleNonDoubleRollForJailedPlayer()
        {
            var playerHasReachedMaxTurnsInJail = jailRoster.GetTurnsFor(playerId) + 1 == maxTurnsInJail;
            
            if (playerHasReachedMaxTurnsInJail)
                ChargePlayerFineAndMoveToDestination();
            else
                jailRoster.AddTurnFor(playerId);
        }

        private void SetJailedPlayerFreeAndMoveToDestination()
        {
            jailRoster.Remove(playerId);
            SendPlayerToDestination();
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
    }
}
