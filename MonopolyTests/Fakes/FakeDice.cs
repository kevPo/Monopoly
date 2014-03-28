using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeDice : IDice
    {
        private Int32 diceRolledCount;
        private List<FakeRoll> rolls;

        public FakeDice()
        { }

        public FakeDice(IEnumerable<FakeRoll> rolls)
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
            return rolls[diceRolledCount - 1].Total();
        }

        public Boolean RollWasDouble()
        {
            return rolls[diceRolledCount - 1].IsDouble();
        }
    }
}
