using System.Collections.Generic;
using Monopoly.Turns;

namespace Monopoly.Board
{
    public class GameBoard : IBoard
    {
        protected IPlayerRepository playerRepository;
        protected IEnumerable<IPlayer> players;
        private ITurnFactory turnFactory;
        
        public GameBoard(IPlayerRepository playerRepository, ITurnFactory turnFactory)
        {
            this.playerRepository = playerRepository;
            this.turnFactory = turnFactory;
            playerRepository.ShufflePlayers();
            PlaceAllPlayersOnStartingLocation();
            players = playerRepository.GetPlayers();
        }

        private void PlaceAllPlayersOnStartingLocation()
        {
            playerRepository.SetAllPlayerLocationsTo(0);
        }

        public void PlayRound()
        {
            foreach (var player in players)
                TakeTurnFor(player);
        }

        protected virtual void TakeTurnFor(IPlayer player)
        {
            var turn = turnFactory.GetTurnFor(player.Id);
            turn.Take();
        }
    }
}
