using System.Collections.Generic;
namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalGameDriver : IGameDriver
    {
        private Game game;

        public TraditionalGameDriver()
        {
            var dice = new TraditionalDice();
            var traditionalBoardFactory = new TraditionalBoardFactory(dice);
            traditionalBoardFactory.Create();
            var traditionalBoard = traditionalBoardFactory.Board;
            game = new Game(traditionalBoard);
        }

        public void PlayGameWith(IEnumerable<IPlayer> players)
        {
            game.SetPlayers(players);
            game.Play();
        }
    }
}
