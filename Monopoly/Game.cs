using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly
{
    public class Game
    {
        public IEnumerable<IPlayer> Players { get; private set; }
        public Int32 Rounds { get; private set; }
        private IBoard board;
        private Starter startingLocation;
        private Random randomDiceGenerator;

        public Game(IEnumerable<IPlayer> players, IBoard board)
        {
            this.Players = players.ToList();
            this.board = board;
            this.startingLocation = board.GetStartingLocation();
            ShufflePlayers();
            randomDiceGenerator = new Random();
        }

        private void ShufflePlayers()
        {
            Players = Players.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public void Play()
        {
            if (Players.Count() < 2 || Players.Count() > 8)
                throw new InvalidOperationException("Game can only be played with 2 - 8 players.");

            PlaceAllPlayersOnStartingLocation();
            
            for (var i = 0; i < 20; i++)
                PlayRound();
        }

        private void PlaceAllPlayersOnStartingLocation()
        {
            foreach (var player in Players)
                player.LandedOn(startingLocation);
        }

        private void PlayRound()
        {
            foreach (var player in Players)
                board.MovePlayer(player, RollDice());

            Rounds++;
        }

        private Int32 RollDice()
        {
            return randomDiceGenerator.Next(2, 13);
        }
    }
}
