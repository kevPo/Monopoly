using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeDiceDoublesRoller : IDice
    {
        private Int32[] doubleRolls;
        private Int32 nextRollAfterDouble;
        private Int32 diceRolledCount;

        public FakeDiceDoublesRoller(Int32[] doubleRolls, Int32 nextRollAfterDouble)
        {
            this.doubleRolls = doubleRolls;
            this.nextRollAfterDouble = nextRollAfterDouble;
            diceRolledCount = 0;
        }

        public void Roll()
        {
            diceRolledCount++;
        }

        public Int32 GetCurrentRoll()
        {
            return diceRolledCount <= doubleRolls.Count() ? doubleRolls[diceRolledCount - 1] : nextRollAfterDouble;
        }

        public Boolean RollWasDouble()
        {
            return diceRolledCount <= doubleRolls.Count();
        }
    }
}
