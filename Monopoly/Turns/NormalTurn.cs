using System;
using Monopoly.Board;
using Monopoly.Dice;
using Monopoly.JailRoster;

namespace Monopoly.Turns
{
    public class NormalTurn : Turn
    {
        private const Int32 maximumRolls = 3;

        public NormalTurn(Int32 playerId, IDice dice, IJailRoster jailRoster, GameBoard board)
            : base (playerId, dice, jailRoster, board)
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
            board.SendPlayerDirectlyToJail(playerId);
            jailRoster.Add(playerId);
        }
    }
}
