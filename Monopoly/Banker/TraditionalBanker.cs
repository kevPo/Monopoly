using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Banker
{
    public class TraditionalBanker : IBanker
    {
        private const Int32 startingBalance = 1500;
        private IDictionary<Int32, Int32> vault;

        public TraditionalBanker(IEnumerable<Int32> playerIds)
        {
            vault = new Dictionary<Int32, Int32>();
            SetUpInitialBalances(playerIds);
        }

        private void SetUpInitialBalances(IEnumerable<Int32> playerIds)
        {
            foreach (var playerId in playerIds)
                vault.Add(playerId, startingBalance);
        }

        public void PayMoneyTo(Int32 playerId, Int32 money)
        {
            vault[playerId] += money;
        }

        public void CollectMoneyFrom(Int32 playerId, Int32 money)
        {
            vault[playerId] -= money;
        }

        public Int32 GetBalanceFor(Int32 playerId)
        {
            return vault[playerId];
        }

        public void TransferMoney(Int32 givingPlayerId, Int32 receivingPlayerId, Int32 money)
        {
            CollectMoneyFrom(givingPlayerId, money);
            PayMoneyTo(receivingPlayerId, money);
        }

        public void ChargeTaxesTo(Int32 playerId, Func<Int32, Int32> taxEquation)
        {
            var taxes = taxEquation(GetBalanceFor(playerId));
            CollectMoneyFrom(playerId, taxes);
        }

        public void CollectMoneyFromAllPlayers(Int32 receivingPlayerId, Int32 money)
        {
            var playerIds = vault.Where(a => a.Key != receivingPlayerId).Select(a => a.Key).ToList();

            foreach (var payingPlayerId in playerIds)
                TransferMoney(payingPlayerId, receivingPlayerId, money);
        }

        public void PayMoneyToAllPlayers(Int32 payingPlayerId, Int32 money)
        {
            var playerIds = vault.Where(a => a.Key != payingPlayerId).Select(a => a.Key).ToList();

            foreach (var receivingPlayerId in playerIds)
                TransferMoney(payingPlayerId, receivingPlayerId, money);
        }
    }
}
