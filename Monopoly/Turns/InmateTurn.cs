using System;
using Monopoly.Dice;
using Monopoly.JailRoster;
using Monopoly.Locations.Managers;

namespace Monopoly.Turns
{
    public class InmateTurn : Turn
    {
        private const Int32 maxTurnsInJail = 3;

		public InmateTurn(Int32 playerId, IDice dice, IJailRoster jailRoster, ILocationManager locationManager)
			: base (playerId, dice, jailRoster, locationManager)
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
            jailRoster.RemoveWithFine(playerId);
            SendPlayerToDestination();
        }
    }
}
