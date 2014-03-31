using System;
using Monopoly.JailRoster;

namespace MonopolyTests.Fakes
{
    public class FakeJailRoster : IJailRoster
    {
        public Boolean IsInJail(Int32 playerId)
        {
            return false;
        }

        public void Add(Int32 playerId)
        {
            
        }

        public void AddTurnFor(Int32 playerId)
        {
            
        }

        public Int32 GetTurnsFor(Int32 playerId)
        {
            return 0;
        }

        public void Remove(Int32 playerId)
        {
            
        }

        public void RemoveWithFine(int playerId)
        {
            
        }
    }
}
