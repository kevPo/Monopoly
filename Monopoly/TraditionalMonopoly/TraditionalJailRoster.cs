using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalJailRoster : IJailRoster
    {
        private Dictionary<Int32, Int32> roster;

        public TraditionalJailRoster()
        {
            roster = new Dictionary<Int32, Int32>();
        }

        public Boolean IsInJail(Int32 playerId)
        {
            return roster.Any(p => p.Key.Equals(playerId));
        }

        public void Add(Int32 playerId)
        {
            roster.Add(playerId, 0);
        }

        public void AddTurnFor(Int32 playerId)
        {
            var currentTurns = roster.First(p => p.Key.Equals(playerId)).Value;
            roster.Remove(playerId);
            roster.Add(playerId, currentTurns + 1);
        }

        public Int32 GetTurnsFor(Int32 playerId)
        {
            return roster.FirstOrDefault(p => p.Key.Equals(playerId)).Value;
        }

        public void Remove(Int32 playerId)
        {
            roster.Remove(playerId);
        }
    }
}
