using System;

namespace Monopoly
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public void RemoveMoneyFrom(Int32 playerId, Int32 money)
        {
            var player = playerRepository.GetPlayer(playerId);
            player.RemoveMoney(money);
        }

        public void AddMoneyTo(Int32 playerId, Int32 money)
        {
            var player = playerRepository.GetPlayer(playerId);
            player.ReceiveMoney(money);
        }

        public void ChargeTaxesTo(Int32 playerId, Func<Int32, Int32> taxEquation)
        {
            var player = playerRepository.GetPlayer(playerId);
            var taxes = taxEquation(player.Balance);
            player.RemoveMoney(taxes);
        }

        public void TransferMoney(Int32 givingPlayerId, Int32 receivingPlayerId, Int32 money)
        {
            var givingPlayer = playerRepository.GetPlayer(givingPlayerId);
            var receivingPlayer = playerRepository.GetPlayer(receivingPlayerId);
            givingPlayer.RemoveMoney(money);
            receivingPlayer.ReceiveMoney(money);
        }

        public void SetLocationIndexFor(Int32 playerId, Int32 locationIndex)
        {
            var player = playerRepository.GetPlayer(playerId);
            player.LocationIndex = locationIndex;
        }

        public Int32 GetLocationIndexFor(Int32 playerId)
        {
            var player = playerRepository.GetPlayer(playerId);

            return player.LocationIndex;
        }

        public Int32 GetBalanceFor(Int32 playerId)
        {
            var player = playerRepository.GetPlayer(playerId);
            return player.Balance;
        }
    }
}
