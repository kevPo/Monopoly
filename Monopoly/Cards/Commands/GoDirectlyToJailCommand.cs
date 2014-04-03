using System;
using Monopoly.Board;
using Monopoly.JailRoster;

namespace Monopoly.Cards.Commands
{
    public class GoDirectlyToJailCommand : ICommand
    {
        private IJailRoster jailRoster;
        private GameBoard board;

        public GoDirectlyToJailCommand(IJailRoster jailRoster, GameBoard board)
        {
            this.jailRoster = jailRoster;
            this.board = board;
        }

        public void PerformOn(Int32 playerId)
        {
            board.SetLocationIndexFor(playerId, 10);
            jailRoster.Add(playerId);
        }
    }
}
