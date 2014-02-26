using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Game
    {
        public List<IPlayer> Players { get; private set; }
        public Int32 Rounds { get; private set; }

        public Game(IEnumerable<IPlayer> players)
        {
            this.Players = players.ToList();
            ShufflePlayers();
        }

        public void Play()
        {
            if (Players.Count() < 2 || Players.Count() > 8)
                throw new InvalidOperationException("Game can only be played with 2 - 8 players.");

            for (var i = 0; i < 20; i++)
                PlayRound();
        }

        private void ShufflePlayers()
        {
            Players = Players.OrderBy(a => Guid.NewGuid()).ToList();
        }

        private void PlayRound()
        {
            foreach (var player in Players)
                player.TakeTurn();

            Rounds++;
        }
    }
}
