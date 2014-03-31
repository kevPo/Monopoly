using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Banker;

namespace Monopoly.JailRoster
{
    public class TraditionalJailRoster : IJailRoster
    {
        private const Int32 jailFine = 50;
        private Dictionary<Int32, Int32> roster;
        private IBanker banker;

        public TraditionalJailRoster(IBanker banker)
        {
            this.banker = banker;
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

        public void RemoveWithFine(Int32 playerId)
        {
            banker.TakeMoneyFrom(playerId, jailFine);
            Remove(playerId);
        }
    }
}
