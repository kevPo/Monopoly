using System;
using Monopoly.Board;
using Monopoly.JailRoster;

namespace Monopoly.Cards.Commands
{
    public class GoDirectlyToJailCommand : ICommand
    {
        private IJailRoster jailRoster;
        private IBoard board;

        public GoDirectlyToJailCommand(IJailRoster jailRoster, IBoard board)
        {
            this.jailRoster = jailRoster;
            this.board = board;
        }

        public void PerformOn(Int32 playerId)
        {
            board.SendPlayerDirectlyToJail(playerId);
            jailRoster.Add(playerId);
        }
    }
}
