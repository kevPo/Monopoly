using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Banker;
using Monopoly.Board;

namespace Monopoly.Cards.Commands
{
    public class AdvanceToNearestRailroadCommand : ICommand
    {
        private IBanker banker;
        private GameBoard board;

        public AdvanceToNearestRailroadCommand(IBanker banker, GameBoard board)
        {
            this.banker = banker;
            this.board = board;
        }

        public void PerformOn(Int32 playerId)
        {
            var railRoad = board.GetNearestRailroadFor(playerId);

            if (!railRoad.IsOwned)
                railRoad.LandedOnBy(playerId);
            else
                banker.TransferMoney(playerId, railRoad.OwnerId, railRoad.GetRentValue() * 2);

            board.SetLocationIndexFor(playerId, railRoad.Index);               
        }
    }
}
