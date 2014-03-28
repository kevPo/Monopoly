using System;
using System.Collections.Generic;
using Monopoly.Locations;

namespace Monopoly.Turns
{
    public class NormalTurn : Turn
    {
        private const Int32 maximumRolls = 3;

        public NormalTurn(Int32 playerId, IDice dice, IJailRoster jailRoster, IPlayerService playerService, IEnumerable<Location> locations)
            : base (playerId, dice, jailRoster, playerService, locations)
        { }

        public override void Take()
        {
            var rollCount = 0;

            do
            {
                dice.Roll();
                rollCount++;
                MovePlayer(rollCount);
            } while (dice.RollWasDouble() && rollCount < maximumRolls && !jailRoster.IsInJail(playerId));
        }

        private void MovePlayer(Int32 rollCount)
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
    }
}
