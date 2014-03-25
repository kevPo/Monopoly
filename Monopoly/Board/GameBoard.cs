using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly.Board
{
    public class GameBoard : IBoard
    {
        public IDice Dice { get; private set; }
        protected IEnumerable<IPlayer> players;
        private IJailRoster jailRoster;
        private IEnumerable<Location> locations;
        
        public GameBoard(IDice dice, IJailRoster jailRoster, IEnumerable<IPlayer> players, IEnumerable<Location> locations)
        {
            Dice = dice;
            this.jailRoster = jailRoster;
            this.locations = locations;
            this.players = players;
            ShufflePlayers();
            PlaceAllPlayersOnStartingLocation();
        }

        private void ShufflePlayers()
        {
            players = players.OrderBy(a => Guid.NewGuid()).ToList();
        }

        private void PlaceAllPlayersOnStartingLocation()
        {
            foreach (var player in players)
                player.LandedOn(0);
        }

        public void PlayRound()
        {
            foreach (var player in players)
                TakeTurnFor(player);
        }

        protected virtual void TakeTurnFor(IPlayer player)
        {
            var turn = new Turn(locations, jailRoster, player, Dice);
            turn.Take();
        }
    }
}
