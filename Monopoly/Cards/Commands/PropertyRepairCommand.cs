using System;

namespace Monopoly.Cards.Commands
{
    public class NullCommand : ICommand
    {
        public void PerformOn(Int32 playerId)
        { }
    }
}
