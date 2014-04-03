using System;
using Monopoly.Banker;

namespace Monopoly.Cards.Commands
{
    public class CollectMoneyFromAllPlayersCommand : ICommand
    {
        private IBanker banker;
        private Int32 money;

        public CollectMoneyFromAllPlayersCommand(IBanker banker, Int32 money)
        {
            this.banker = banker;
            this.money = money;
        }

        public void PerformOn(Int32 playerId)
        {
            banker.CollectMoneyFromAllPlayers(playerId, money);
        }
    }
}
