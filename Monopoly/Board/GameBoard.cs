using System.Collections.Generic;

namespace Monopoly.Board
{
    public class GameBoard : IBoard
    {
        protected IPlayerRepository playerRepository;
        protected IEnumerable<IPlayer> players;
        private Turn turn;
        
        public GameBoard(IPlayerRepository playerRepository, Turn turn)
        {
            this.playerRepository = playerRepository;
            this.turn = turn;
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
            turn.TakeFor(player.Id);
        }
    }
}
