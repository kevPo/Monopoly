using System;
namespace Monopoly.Cards
{
    public interface ICard
    {
        void InvokeActionFor(Int32 playerId);
    }
}
