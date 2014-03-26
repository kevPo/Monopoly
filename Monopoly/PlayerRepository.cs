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

        public IPlayer GetPlayer(Guid id)
        {
            return players.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePlayer(Guid id)
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
    }
}
