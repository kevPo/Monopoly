using System;
namespace Monopoly.JailRoster
{
    public interface IJailRoster
    {
        Boolean IsInJail(Int32 playerId);
        void Add(Int32 playerId);
        void AddTurnFor(Int32 playerId);
        Int32 GetTurnsFor(Int32 playerId);
        void Remove(Int32 playerId);
        void RemoveWithFine(Int32 playerId);
    }
}
