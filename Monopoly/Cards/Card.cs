using System;
using Monopoly.Cards.Commands;

namespace Monopoly.Cards
{
    public class Card : ICard
    {
        private ICommand command;

        public Card(ICommand command)
        {
            this.command = command;
        }

        public void InvokeActionFor(Int32 playerId)
        {
            command.PerformOn(playerId);
        }
    }
}
