using System;

namespace Monopoly
{
    public interface IJailRoster
    {
        Boolean IsInJail(Int32 playerId);
        void Add(Int32 playerId);
        void AddTurnFor(Int32 playerId);
        Int32 GetTurnsFor(Int32 playerId);
        void Remove(Int32 playerId);
    }
}
