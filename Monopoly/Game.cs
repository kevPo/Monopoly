using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Game
    {
        public List<Player> Players { get; private set; }

        public Game(IEnumerable<Player> players)
        {
            this.Players = players.ToList();
            ShufflePlayers();
        }

        public void Play()
        {
            if (Players.Count() < 2 || Players.Count() > 8)
            {
                throw new InvalidOperationException("Game can only be played with 2 - 8 players.");
            }
        }

        private void ShufflePlayers()
        {
            Players = Players.OrderBy(a => Guid.NewGuid()).ToList();
        }
    }
}
