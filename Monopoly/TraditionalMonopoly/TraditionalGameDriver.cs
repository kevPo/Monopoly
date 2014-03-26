using System;
using System.Collections.Generic;
using System.Linq;
namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalGameDriver : IGameDriver
    {
        private const Int32 minimumPlayers = 2;
        private const Int32 maximumPlayers = 8;

        private IDice dice;
        private IJailRoster jailRoster;

        public TraditionalGameDriver()
        {
            dice = new TraditionalDice();
            jailRoster = new TraditionalJailRoster();
        }

        public void PlayGameWith(IEnumerable<String> tokens)
        {
            if (tokens.Count() < minimumPlayers || tokens.Count() > maximumPlayers)
                throw new InvalidOperationException(String.Format("Game can only be played with {0} - {1} players.", minimumPlayers, maximumPlayers));

            var players = CreatePlayersFor(tokens);
            var playerRepository = new PlayerRepository(players);
            var traditionalBoardFactory = new TraditionalBoardFactory(dice, playerRepository, jailRoster);
            var traditionalBoard = traditionalBoardFactory.GetBoard();
            var game = new Game(traditionalBoard);
            
            game.Play();
        }

        private IEnumerable<IPlayer> CreatePlayersFor(IEnumerable<String> tokens)
        {
            var players = new List<IPlayer>();
            var tokensArray = tokens.ToArray();

            for (var id = 0; id < tokensArray.Count(); id++)
                players.Add(new Player(id, tokensArray[id], 1500));

            return players;
        }
    }
}
