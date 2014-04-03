using System;
using Monopoly.Banker;

namespace Monopoly.Cards.Commands
{
    public class PropertyRepairCommand : ICommand
    {
        private IBanker banker;

        public PropertyRepairCommand(IBanker banker, Int32 moneyForHouse, Int32 moneyForHotel)
        {
            this.banker = banker;
        }

        public void PerformOn(Int32 playerId)
        {
            
        }
    }
}
