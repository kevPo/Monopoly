using System;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.JailRoster;

namespace Monopoly.Locations.Defaults
{
    public class GoToJail : Location
    {
        private Int32 jailIndex;
        private IJailRoster jailRoster;
        private GameBoard board;

        public GoToJail(Int32 index, String name, Int32 jailIndex, IBanker banker, 
                        IJailRoster jailRoster, GameBoard board) : base(index, name, banker)
        {
            this.jailIndex = jailIndex;
            this.jailRoster = jailRoster;
            this.board = board;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            board.SetLocationIndexFor(playerId, jailIndex);
            jailRoster.Add(playerId);
        }
    }
}
