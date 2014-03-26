using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class PlayerRepository : IPlayerRepository
    {
        private HashSet<IPlayer> players;

        public PlayerRepository(IEnumerable<IPlayer> players)
        {
            this.players = new HashSet<IPlayer>(players);
        }

        public IPlayer GetPlayer(Int32 id)
        {
            return players.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePlayer(Int32 id)
        {
            players.Remove(GetPlayer(id));
        }

        public IEnumerable<IPlayer> GetPlayers()
        {
            return players;
        }

        public void ShufflePlayers()
        {
            players = new HashSet<IPlayer>(players.OrderBy(a => Guid.NewGuid()));
        }

        public void SetAllPlayerLocationsTo(Int32 locationIndex)
        {
            foreach (var player in players)
                player.LocationIndex = locationIndex;
        }

        public void SetLocationIndexFor(Int32 playerId, Int32 locationIndex)
        {
            var player = GetPlayer(playerId);
            player.LocationIndex = locationIndex;
        }

        public Int32 GetLocationIndexFor(Int32 playerId)
        {
            var player = GetPlayer(playerId);

            return player.LocationIndex;
        }

        public void RemoveMoneyFrom(Int32 playerId, Int32 money)
        {
            var player = GetPlayer(playerId);
            player.RemoveMoney(money);
        }

        public void AddMoneyTo(Int32 playerId, Int32 money)
        {
            var player = GetPlayer(playerId);
            player.ReceiveMoney(money);
        }

        public void ChargeTaxesTo(Int32 playerId, Func<Int32, Int32> taxEquation)
        {
            var player = GetPlayer(playerId);
            var taxes = taxEquation(player.Balance);
            player.RemoveMoney(taxes);
        }

        public void TransferMoney(Int32 givingPlayerId, Int32 receivingPlayerId, Int32 money)
        {
            var givingPlayer = GetPlayer(givingPlayerId);
            var receivingPlayer = GetPlayer(receivingPlayerId);
            givingPlayer.RemoveMoney(money);
            receivingPlayer.ReceiveMoney(money);
        }

        public void UpdatePlayer(IPlayer player)
        {
            var playerToUpdate = GetPlayer(player.Id);
            playerToUpdate = player;
        }

        public Int32 GetBalanceFor(Int32 playerId)
        {
            var player = GetPlayer(playerId);
            return player.Balance;
        }
    }
}
