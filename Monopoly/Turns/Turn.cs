using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Board;
using Monopoly.Dice;
using Monopoly.JailRoster;
using Monopoly.Locations.Defaults;

namespace Monopoly.Turns
{
    public abstract class Turn
    {
        protected Int32 playerId;
        protected IDice dice;
        protected IJailRoster jailRoster;
        protected IBoard board;
        protected Int32 currentLocationIndex;
        protected IEnumerable<Location> locations;

        public Turn(Int32 playerId, IDice dice, IJailRoster jailRoster, IBoard board)
        {
            this.playerId = playerId;
            this.dice = dice;
            this.jailRoster = jailRoster;
            this.board = board;
            this.locations = board.Locations;
        }

        public abstract void Take();

        protected void SendPlayerToDestination()
        {
            var diceRoll = dice.GetCurrentRoll();
            board.MovePlayer(playerId, diceRoll);
        }
    }
}
