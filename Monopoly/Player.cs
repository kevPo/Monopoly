using System;

namespace Monopoly
{
    public class Player : IPlayer
    {
        public String Location { get; private set; }
        public String Name { get; private set; }
        public Int32 Balance { get; private set; }
        private GameMediator gameMediator;

        public Player(String name, Int32 balance, GameMediator gameMediator)
        {
            this.Name = name;
            this.Balance = balance;
            this.gameMediator = gameMediator;
        }

        public void TakeTurn(Int32 rolled)
        {
            InitializeIfFirstTurn();

            var result = gameMediator.MovePlayer(this, rolled);
            Location = result.Location;
            Balance += result.CurrencyGained;
        }

        private void InitializeIfFirstTurn()
        {
            if (String.IsNullOrEmpty(Location))
                Location = gameMediator.GetStartingPosition();
        }
    }
}
