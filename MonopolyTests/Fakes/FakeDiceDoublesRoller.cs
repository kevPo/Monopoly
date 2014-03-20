using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeDiceDoublesRoller : IDice
    {
        private Int32 diceRolledCount;
        private List<Tuple<Int32, String>> rolls;

        public FakeDiceDoublesRoller(IEnumerable<Tuple<Int32, String>> rolls)
        {
            this.rolls = rolls.ToList();
            diceRolledCount = 0;
        }

        public void Roll()
        {
            diceRolledCount++;
        }

        public Int32 GetCurrentRoll()
        {
            return rolls[diceRolledCount - 1].Item1;
        }

        public Boolean RollWasDouble()
        {
            return rolls[diceRolledCount - 1].Item2 == "D";
        }
    }
}
