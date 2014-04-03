using System;
using Monopoly.Banker;

namespace Monopoly.Cards.Commands
{
    public class PayMoneyCommand : ICommand
    {
        private IBanker banker;
        private Int32 money;

        public PayMoneyCommand(IBanker banker, Int32 money)
        {
            this.banker = banker;
            this.money = money;
        }

        public void PerformOn(Int32 playerId)
        {
            banker.CollectMoneyFrom(playerId, money);
        }
    }
}
