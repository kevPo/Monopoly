using System.Collections.Generic;
using Monopoly.Locations;

namespace Monopoly.Board
{
    public class GameBoard : IBoard
    {
        public IDice Dice { get; private set; }
        protected IPlayerRepository playerRepository;
        protected IEnumerable<IPlayer> players;
        private IJailRoster jailRoster;
        private IEnumerable<Location> locations;
        private Turn turn;
        
        public GameBoard(IDice dice, IJailRoster jailRoster, 
                         IPlayerRepository playerRepository, IEnumerable<Location> locations)
        {
            Dice = dice;
            this.jailRoster = jailRoster;
            this.locations = locations;
            this.playerRepository = playerRepository;
            turn = new Turn(locations, jailRoster, playerRepository, Dice);
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
