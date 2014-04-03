using System;
using Monopoly.Banker;

namespace Monopoly.Cards.Commands
{
    public class PayEachPlayerCommand : ICommand
    {
        private IBanker banker;
        private Int32 money;

        public PayEachPlayerCommand(IBanker banker, Int32 money)
        {
            this.banker = banker;
            this.money = money;
        }

        public void PerformOn(Int32 playerId)
        {
            banker.PayMoneyToAllPlayers(playerId, money);
        }
    }
}
