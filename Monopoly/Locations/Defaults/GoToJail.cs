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
        private IBoard board;

        public GoToJail(Int32 index, String name, Int32 jailIndex, IBanker banker,
                        IJailRoster jailRoster, IBoard board)
            : base(index, name)
        {
            this.jailIndex = jailIndex;
            this.jailRoster = jailRoster;
            this.board = board;
        }

        public override void LandedOnBy(Int32 playerId)
        {
            board.SendPlayerDirectlyTo(playerId, jailIndex);
            jailRoster.Add(playerId);
        }
    }
}
