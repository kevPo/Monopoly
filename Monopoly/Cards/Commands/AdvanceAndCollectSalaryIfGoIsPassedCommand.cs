using System;
using Monopoly.Banker;
using Monopoly.Board;

namespace Monopoly.Cards.Commands
{
    public class AdvanceAndCollectSalaryIfGoIsPassedCommand : AdvanceTokenCommand
    {
        private IBanker banker;
        
        public AdvanceAndCollectSalaryIfGoIsPassedCommand(Int32 locationIndex, 
            GameBoard board, IBanker banker) : base (locationIndex, board)
        {
            this.banker = banker;
        }

        public override void PerformOn(Int32 playerId)
        {
            var currentLocationOfPlayer = board.GetLocationIndexFor(playerId);

            if (locationIndex < currentLocationOfPlayer)
                banker.PayMoneyTo(playerId, 200);

            base.PerformOn(playerId);
        }
    }
}
