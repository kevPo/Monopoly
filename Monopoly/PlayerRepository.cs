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
    }
}
