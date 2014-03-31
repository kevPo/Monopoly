using System;
using System.Collections.Generic;

namespace Monopoly.Banker
{
    public class TraditionalBanker : IBanker
    {
        private IDictionary<Int32, Int32> vault;

        public TraditionalBanker(IEnumerable<Int32> playerIds)
        {
            vault = new Dictionary<Int32, Int32>();
            SetUpInitialAmounts(playerIds);
        }

        private void SetUpInitialAmounts(IEnumerable<Int32> playerIds)
        {
            foreach (var playerId in playerIds)
                vault.Add(playerId, 1500);
        }

        public void GiveMoneyTo(Int32 playerId, Int32 money)
        {
            vault[playerId] += money;
        }

        public void TakeMoneyFrom(Int32 playerId, Int32 money)
        {
            vault[playerId] -= money;
        }

        public Int32 GetBalanceFor(Int32 playerId)
        {
            return vault[playerId];
        }

        public void TransferMoney(Int32 givingPlayerId, Int32 receivingPlayerId, Int32 money)
        {
            TakeMoneyFrom(givingPlayerId, money);
            GiveMoneyTo(receivingPlayerId, money);
        }

        public void ChargeTaxesTo(Int32 playerId, Func<Int32, Int32> taxEquation)
        {
            var taxes = taxEquation(GetBalanceFor(playerId));
            TakeMoneyFrom(playerId, taxes);
        }
    }
}
