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

        public void PlayGameWith(IEnumerable<IPlayer> players)
        {
            if (players.Count() < minimumPlayers || players.Count() > maximumPlayers)
                throw new InvalidOperationException(String.Format("Game can only be played with {0} - {1} players.", minimumPlayers, maximumPlayers));

            var traditionalBoardFactory = new TraditionalBoardFactory(dice, players, jailRoster);
            var traditionalBoard = traditionalBoardFactory.GetBoard();
            var game = new Game(traditionalBoard);
            
            game.Play();
        }
    }
}
