using System;

namespace Monopoly
{
    public class Player : IPlayer
    {
        public Location Location { get; private set; }
        public String Name { get; private set; }
        public Int32 Balance { get; private set; }
        private IBoard board;

        public Player(String name, Int32 balance, IBoard board)
        {
            this.Name = name;
            this.Balance = balance;
            this.board = board;
            Location = board.GetStartingLocation();
        }

        public void TakeTurn(Int32 rolled)
        {
            board.MovePlayer(this, rolled);
        }

        public void PayTax(Int32 tax)
        {
            Balance -= tax;
        }

        public void ReceiveMoney(Int32 dollars)
        {
            Balance += dollars;
        }

        public void GoDirectlyTo(String locationName)
        {
            Location = board.GetLocationFor(locationName);
        }

        public void LandedOn(Location location)
        {
            Location = location;
            location.LandedOnBy(this);
        }
    }
}
