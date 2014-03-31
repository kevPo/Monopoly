using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Players
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

        public IEnumerable<Int32> GetPlayerIds()
        {
            return players.Select(p => p.Id);
        }

        public void ShufflePlayers()
        {
            players = new HashSet<IPlayer>(players.OrderBy(a => Guid.NewGuid()));
        }
    }
}
