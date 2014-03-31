using Monopoly.Players;
using Monopoly.Turns;
namespace Monopoly.Board
{
    public abstract class BoardFactory
    {
        protected IPlayerRepository playerRepository;

        public BoardFactory(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public IBoard GetBoard()
        {
            return new GameBoard(playerRepository, GetTurnFactory());            
        }

        protected abstract ITurnFactory GetTurnFactory();
    }
}
