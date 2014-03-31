using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Board;
using Monopoly.Players;
namespace Monopoly.Game
{
    public class TraditionalGameDriver : IGameDriver
    {
        private const Int32 minimumPlayers = 2;
        private const Int32 maximumPlayers = 8;

        public void PlayGameWith(IEnumerable<String> tokens)
        {
            if (tokens.Count() < minimumPlayers || tokens.Count() > maximumPlayers)
                throw new InvalidOperationException(String.Format("Game can only be played with {0} - {1} players.", minimumPlayers, maximumPlayers));

            var players = CreatePlayersFor(tokens);
            var playerRepository = new PlayerRepository(players);
            var traditionalBoardFactory = new TraditionalBoardFactory(playerRepository);
            var traditionalBoard = traditionalBoardFactory.GetBoard();
            var game = new Game(traditionalBoard);
            
            game.Play();
        }

        private IEnumerable<Player> CreatePlayersFor(IEnumerable<String> tokens)
        {
            var players = new List<Player>();
            var tokensArray = tokens.ToArray();

            for (var id = 0; id < tokensArray.Count(); id++)
                players.Add(new Player(id, tokensArray[id]));

            return players;
        }
    }
}
