using System;

namespace Monopoly
{
    public class Player : IPlayer
    {
        public String Location { get; private set; }
        public String Name { get; private set; }
        public Int32 Balance { get; private set; }
        private Board board;

        public Player(String name, Board board)
        {
            this.Name = name;
            this.board = board;
        }

        public void TakeTurn(Int32 rolled)
        {
            InitializeIfFirstTurn();

            var result = board.UpdateLocation(Location, rolled);
            Location = result.Location;
            Balance += result.CurrencyGained;
        }

        private void InitializeIfFirstTurn()
        {
            if (String.IsNullOrEmpty(Location))
            {
                Location = board.GetStartingLocation();
                Balance = 0;
            }
        }
    }
}
