using System;
namespace Monopoly.Cards.Commands
{
    public interface ICommand
    {
        void PerformOn(Int32 playerId);
    }
}
