using Monopoly.Banker;
using Monopoly.Board;
using Monopoly.Players;
using Monopoly.Turns;
namespace Monopoly.Board
{
    public class TraditionalBoardFactory : BoardFactory
    {
        private TraditionalBanker banker;

        public TraditionalBoardFactory(IPlayerRepository playerRepository) : base(playerRepository)
        {
            banker = new TraditionalBanker(playerRepository.GetPlayerIds());
        }

        protected override ITurnFactory GetTurnFactory()
        {
            return new TraditionalTurnFactory(banker);
        }
    }
}
