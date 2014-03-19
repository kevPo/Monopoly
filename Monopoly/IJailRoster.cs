using System;

namespace Monopoly
{
    public interface IJailRoster
    {
        Boolean IsInJail(IPlayer player);
        void Add(IPlayer player);
        void AddTurnFor(IPlayer player);
        Int32 GetTurnsFor(IPlayer player);
        void Remove(IPlayer player);
    }
}
