using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.TraditionalMonopoly
{
    public class TraditionalJailRoster : IJailRoster
    {
        private Dictionary<IPlayer, Int32> roster;

        public TraditionalJailRoster()
        {
            roster = new Dictionary<IPlayer, Int32>();
        }

        public Boolean IsInJail(IPlayer player)
        {
            return roster.Any(p => p.Key.Equals(player));
        }

        public void Add(IPlayer player)
        {
            roster.Add(player, 0);
        }

        public void AddTurnFor(IPlayer player)
        {
            var currentTurns = roster.First(p => p.Key.Equals(player)).Value;
            roster.Remove(player);
            roster.Add(player, currentTurns + 1);
        }

        public Int32 GetTurnsFor(IPlayer player)
        {
            return roster.FirstOrDefault(p => p.Key.Equals(player)).Value;
        }

        public void Remove(IPlayer player)
        {
            roster.Remove(player);
        }
    }
}
