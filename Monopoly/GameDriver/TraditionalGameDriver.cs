using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Players;
using Monopoly.Turns;

namespace Monopoly.GameDriver
{
    public class TraditionalGameDriver : IGameDriver
    {
        private const Int32 minimumPlayers = 2;
        private const Int32 maximumPlayers = 8;

        private IEnumerable<IPlayer> players;
        private Game game;

        public void PlayGameWith(IEnumerable<String> tokens)
        {
            ValidatePlayerSize(tokens);
            CreatePlayersFor(tokens);
            CreateAndPlayGame(players.Select(p => p.Id));
        }

        private void ValidatePlayerSize(IEnumerable<String> tokens)
        {
            var playerError = String.Format("Game can only be played with {0} - {1} players.",
                minimumPlayers, maximumPlayers);

            if (tokens.Count() < minimumPlayers || tokens.Count() > maximumPlayers)
                throw new InvalidOperationException(playerError);
        }

        private void CreatePlayersFor(IEnumerable<String> tokens)
        {
            var addedPlayers = new List<Player>();
            var tokensArray = tokens.ToArray();

            for (var id = 0; id < tokensArray.Count(); id++)
                addedPlayers.Add(new Player(id, tokensArray[id]));

            players = addedPlayers;
        }

        private void CreateAndPlayGame(IEnumerable<Int32> playerIds)
        {
            var banker = new TraditionalBanker(playerIds);
            var turnFactory = new TraditionalTurnFactory(banker);
            game = new Game(playerIds, turnFactory);
            game.Play();
        }

        public Int32 GetRoundsPlayed()
        {
            if (game != null)
                return game.Rounds;

            return 0;
        }
    }
}
