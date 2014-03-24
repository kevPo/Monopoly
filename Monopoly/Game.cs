﻿using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Board;

namespace Monopoly
{
    public class Game
    {
        private const Int32 minimumPlayers = 2;
        private const Int32 maximumPlayers = 8;

        public IEnumerable<IPlayer> Players { get; private set; }
        public Int32 Rounds { get; private set; }
        private IBoard board;

        public Game(IBoard board)
        {
            this.board = board;
        }

        public void SetPlayers(IEnumerable<IPlayer> players)
        {
            Players = players.ToList();
            ShufflePlayers();
        }

        private void ShufflePlayers()
        {
            Players = Players.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public void Play()
        {
            if (Players.Count() < minimumPlayers || Players.Count() > maximumPlayers)
                throw new InvalidOperationException(String.Format("Game can only be played with {0} - {1} players.", minimumPlayers, maximumPlayers));

            PlaceAllPlayersOnStartingLocation();
            PlayGame();
        }

        private void PlayGame()
        {
            for (var i = 0; i < 20; i++)
                PlayRoundForEachPlayer();
        }

        private void PlaceAllPlayersOnStartingLocation()
        {
            foreach (var player in Players)
                player.LandedOn(0);
        }

        private void PlayRoundForEachPlayer()
        {
            foreach (var player in Players)
                board.TakeTurnFor(player);

            Rounds++;
        }
    }
}
