using System;
using Monopoly.Dice;
using Monopoly.JailRoster;
using Monopoly.Locations.Managers;

namespace Monopoly.Turns
{
    public class NormalTurn : Turn
    {
        private const Int32 maximumRolls = 3;

        public NormalTurn(Int32 playerId, IDice dice, IJailRoster jailRoster, ILocationManager locationManager)
            : base (playerId, dice, jailRoster, locationManager)
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
            locationManager.SetLocationIndexFor(playerId, 10);
            jailRoster.Add(playerId);
        }
    }
}
