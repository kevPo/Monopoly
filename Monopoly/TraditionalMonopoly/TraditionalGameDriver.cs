using System.Collections.Generic;
namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalGameDriver
    {
        private Game game;

        public TraditionalGameDriver()
        {
            game = new Game();
            var dice = new TraditionalDice();
            game.ConstructBoard(new TraditionalBoardBuilder(dice));
        }

        public void PlayGameWith(IEnumerable<IPlayer> players)
        {
            game.SetPlayers(players);
            game.Play();
        }
    }
}
