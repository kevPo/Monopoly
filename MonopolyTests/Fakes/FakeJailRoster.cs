using System;
using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeJailRoster : IJailRoster
    {
        public bool IsInJail(IPlayer player)
        {
            return false;
        }

        public void Add(IPlayer player)
        {
            
        }

        public void AddTurnFor(IPlayer player)
        {
            
        }

        public Int32 GetTurnsFor(IPlayer player)
        {
            return 0;
        }

        public void Remove(IPlayer player)
        {
            
        }
    }
}
