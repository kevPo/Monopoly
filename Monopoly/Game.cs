using System;
using Monopoly.Board;

namespace Monopoly
{
    public class Game
    {
        public Int32 Rounds { get; private set; }
        private IBoard board;

        public Game(IBoard board)
        {
            this.board = board;
            Rounds = 0;
        }

        public void Play()
        {
            for (var i = 0; i < 20; i++)
            {
                board.PlayRound();
                Rounds++;
            }
        }
    }
}
